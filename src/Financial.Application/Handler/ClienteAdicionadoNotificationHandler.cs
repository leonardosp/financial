using Financial.Cross.Message.Interface;
using Financial.Domain.Clientes.Events;
using MediatR;

namespace Financial.Application.Handler;

public class ClienteAdicionadoNotificationHandler : INotificationHandler<ClienteAdicionadoSolicitaCartaoEvent>,
                                                    INotificationHandler<ClienteAdicionadoSolicitaConsignadoEvent>
{
    private readonly IMessageBus _bus;

    public ClienteAdicionadoNotificationHandler(IMessageBus bus)
    {
        _bus = bus;
    }

    public async Task Handle(ClienteAdicionadoSolicitaCartaoEvent notification, CancellationToken cancellationToken)
    {
        await _bus.PublishAsync(notification);
    }

    public async Task Handle(ClienteAdicionadoSolicitaConsignadoEvent notification, CancellationToken cancellationToken)
    {
        await _bus.PublishAsync(notification);
    }
}
