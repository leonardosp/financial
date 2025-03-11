using Financial.Domain.Clientes;
using Financial.Domain.Clientes.Commands;
using Financial.Domain.Clientes.Commands.Handler;
using Financial.Domain.Clientes.Queries;
using Financial.Domain.Clientes.Queries.Handler;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Domain.DI;

public static class DomainRegisterCommands
{
    public static IServiceCollection RegisterDomainCommands(this IServiceCollection services)
    {
        //Clientes
        services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
        services.AddScoped<IRequestHandler<ObterClientePorCpfQuerie, Cliente>, ClienteQueriesHandler>();
        services.AddScoped<IRequestHandler<ObterClientePorIdQuerie, Cliente>, ClienteQueriesHandler>();

        return services;
    }
}
