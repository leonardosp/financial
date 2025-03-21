﻿using EasyNetQ;
using Financial.Cross.Message.Interface;
using Financial.Cross.Messages;
using Polly;
using RabbitMQ.Client.Exceptions;

namespace Financial.Cross.Message;

public class MessageBus : IMessageBus
{
    private IBus _bus;
    private IAdvancedBus _advancedBus;

    private readonly string _connectionString;

    public MessageBus(string connectionString)
    {
        _connectionString = connectionString;
        TryConnect();
    }

    public bool IsConnected => _bus?.IsConnected ?? false;
    public IAdvancedBus AdvancedBus => _bus?.Advanced;

    public void Publish<T>(T message) where T : Event
    {
        TryConnect();
        _bus.Publish(message);
    }

    public async Task PublishAsync<T>(T message) where T : Event
    {
        TryConnect();
        await _bus.PublishAsync(message);
    }

    public TResponse Request<TRequest, TResponse>(TRequest request)
        where TRequest : Event
        where TResponse : ResponseMessage
    {
        TryConnect();
        return _bus.Request<TRequest, TResponse>(request);
    }

    public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        where TRequest : Event
        where TResponse : ResponseMessage
    {
        TryConnect();
        return await _bus.RequestAsync<TRequest, TResponse>(request);
    }

    public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
        where TRequest : Event
        where TResponse : ResponseMessage
    {
        TryConnect();
        return _bus.Respond(responder);
    }

    public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
        where TRequest : Event
        where TResponse : ResponseMessage
    {
        TryConnect();
        return _bus.RespondAsync(responder);
    }

    public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
    {
        TryConnect();
        _bus.Subscribe(subscriptionId, onMessage);
    }

    public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
    {
        TryConnect();
        _bus.SubscribeAsync(subscriptionId, onMessage);
    }

    private void TryConnect()
    {
        if (IsConnected) return;

        var policy = Policy.Handle<EasyNetQException>()
            .Or<BrokerUnreachableException>()
            .WaitAndRetry(3, retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        policy.Execute(() =>
        {
            _bus = RabbitHutch.CreateBus(_connectionString);
            _advancedBus = _bus.Advanced;
            _advancedBus.Disconnected += OnDisconnect;
        });
    }

    private void OnDisconnect(object s, EventArgs e)
    {
        var policy = Policy.Handle<EasyNetQException>()
            .Or<BrokerUnreachableException>()
            .RetryForever();

        policy.Execute(TryConnect);
    }

    public void Dispose()
    {
        _bus.Dispose();
    }
}
