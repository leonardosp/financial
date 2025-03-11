using EasyNetQ;
using Financial.Cross.Messages;

namespace Financial.Cross.Message.Interface;

public interface IMessageBus : IDisposable
{
    bool IsConnected { get; }
    IAdvancedBus AdvancedBus { get; }

    void Publish<T>(T message) where T : Event;

    Task PublishAsync<T>(T message) where T : Event;

    void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class;

    void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

    TResponse Request<TRequest, TResponse>(TRequest request)
        where TRequest : Event
        where TResponse : ResponseMessage;

    Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        where TRequest : Event
        where TResponse : ResponseMessage;

    IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
        where TRequest : Event
        where TResponse : ResponseMessage;

    IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
        where TRequest : Event
        where TResponse : ResponseMessage;
}
