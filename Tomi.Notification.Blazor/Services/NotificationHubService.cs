using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Tomi.Notification.Core;

namespace Tomi.Notification.Blazor.Services
{
    public class NotificationHubService
    {
        private HubConnection _hubConnection;
        private NotificationJsInterop _notificationApiInterop;
        private ILogger<NotificationHubService> _logger;

        public NotificationHubService(
            NotificationHubServiceOptions notificationHubServiceOptions,
            ILogger<NotificationHubService> logger,
            IJSRuntime jsRuntime)
        {

            _notificationApiInterop = new NotificationJsInterop(jsRuntime);
            _logger = logger;
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(notificationHubServiceOptions.Uri, options =>
                {
                    options.AccessTokenProvider = notificationHubServiceOptions.AccessTokenProvider;
                })
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<string, string, string>(nameof(INotificationClient.ReceiveNotification),
                async (title, description, iconurl) =>
                {
                    await _notificationApiInterop.Notify(title, description, iconurl);
                });

            _hubConnection.On(nameof(INotificationClient.ReceivePermissionRequest),
                async () =>
                {
                    await _notificationApiInterop.AskForApproval();
                });
        }

        public async Task Start()
        {
            await _hubConnection.StartAsync();
        }

        public async Task Stop()
        {
            await _hubConnection.StopAsync();
        }
    }
}
