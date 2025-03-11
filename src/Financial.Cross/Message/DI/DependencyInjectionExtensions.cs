using Financial.Cross.Message.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Cross.Message.DI;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
    {
        if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException();

        services.AddSingleton<IMessageBus>(new MessageBus(connection));

        return services;
    }
}
