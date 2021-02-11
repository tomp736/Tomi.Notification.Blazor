using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tomi.Notification.AspNetCore.Hubs;
using Tomi.Notification.Core;

namespace Tomi.Notification.AspNetCore.Services
{
    public class NotificationHostedService : BackgroundService
    {
        private IHubContext<NotificationHub, INotificationHubService> _hubContext;
        private IServiceProvider _services { get; }

        public NotificationHostedService(IHubContext<NotificationHub, INotificationHubService> hubContext, IServiceProvider services)
        {
            _hubContext = hubContext;
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _services.CreateScope())
            {
                var notificationProcessingServiceDataProvider = scope.ServiceProvider.GetRequiredService<INotificationProcessingServiceDataProvider>();
                var notificationProcessingService = scope.ServiceProvider.GetRequiredService<INotificationProcessingService>();
                await notificationProcessingService.ProcessNotifications(_hubContext, notificationProcessingServiceDataProvider, stoppingToken);
            }
        }
    }
}
