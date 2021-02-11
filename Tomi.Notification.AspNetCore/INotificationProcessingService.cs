using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;
using Tomi.Notification.AspNetCore.Hubs;
using Tomi.Notification.Core;

namespace Tomi.Notification.AspNetCore
{
    public interface INotificationProcessingService
    {
        Task ProcessNotifications(IHubContext<NotificationHub, INotificationHubService> hubContext, INotificationProcessingServiceDataProvider dataProvider, CancellationToken stoppingToken);
    }
}
