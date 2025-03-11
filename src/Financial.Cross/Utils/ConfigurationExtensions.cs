using Microsoft.Extensions.Configuration;

namespace Financial.Cross.Utils;

public static class ConfigurationExtensions
{
    public static string GetMessageQueueConnection(this IConfiguration configuration, string name)
    {
        return configuration?.GetSection("MessageQueueConnection")?[name];
    }
}