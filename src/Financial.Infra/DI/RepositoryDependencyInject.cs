using Financial.Domain.Clientes.Interface;
using Financial.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Infra.DI;

public static class RepositoryDependencyInject
{
    public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();

        services.AddScoped<FinancialDbContext>();

        return services;
    }
}
