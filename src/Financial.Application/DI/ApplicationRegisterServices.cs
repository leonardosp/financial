using Financial.Application.Handler;
using Financial.Application.Services;
using Financial.Application.Services.Interfaces;
using Financial.Cross.Mediator;
using Financial.Domain.Clientes.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Application.DI;

public static class ApplicationRegisterServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IClienteAppService, ClienteAppService>();
        services.AddScoped<INotificationHandler<ClienteAdicionadoSolicitaCartaoEvent>, ClienteAdicionadoNotificationHandler>();
        services.AddScoped<INotificationHandler<ClienteAdicionadoSolicitaConsignadoEvent>, ClienteAdicionadoNotificationHandler>();
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        return services;
    }
}
