using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tomi.Notification.Blazor.Services
{
    public static class NotificationHubServiceExtensions
    {
        public static void AddNotificationHub(this IServiceCollection serviceCollection, Action<IServiceProvider, NotificationHubServiceOptions> configureHub = null)
        {
            NotificationHubServiceOptions notificationHubServiceOptions = new NotificationHubServiceOptions(serviceCollection);
            configureHub?.Invoke(serviceCollection.BuildServiceProvider(), notificationHubServiceOptions);
            serviceCollection.AddScoped<NotificationHubServiceOptions>(options => notificationHubServiceOptions);
            serviceCollection.AddScoped<NotificationHubService>();
        }
    }
}
