using Microsoft.Extensions.DependencyInjection;

namespace Tomi.Notification.AspNetCore.Services
{
    public class NotificationHostedServiceOptions
    {
        public readonly IServiceCollection Services;
        
        public NotificationHostedServiceOptions(IServiceCollection serviceCollection)
        {
            serviceCollection = Services;
        }
    }
}
