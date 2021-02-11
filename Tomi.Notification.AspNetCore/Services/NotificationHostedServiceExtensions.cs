using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tomi.Notification.AspNetCore.Services
{
    public static class NotificationHostedServiceExtensions
    {
        public static void AddNotificationHostedService(this IServiceCollection serviceCollection, Action<IServiceProvider, NotificationHostedServiceOptions> configureHostedService = null)
        {
            NotificationHostedServiceOptions notificationHostedServiceOptions = new NotificationHostedServiceOptions(serviceCollection);
            configureHostedService?.Invoke(serviceCollection.BuildServiceProvider(), notificationHostedServiceOptions);
            serviceCollection.AddScoped<NotificationHostedServiceOptions>(options => notificationHostedServiceOptions);
            serviceCollection.AddHostedService<NotificationHostedService>();
        }
    }
}
