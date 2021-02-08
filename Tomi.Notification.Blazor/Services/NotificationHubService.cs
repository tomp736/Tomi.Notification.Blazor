using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Threading.Tasks;

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
                .Build();

            _hubConnection.On<string, string, string>("ReceiveNotification",
                async (title, description, iconurl) =>
                {
                    _logger.LogInformation($"{title}");
                    await ShowNotification(title, description, iconurl);
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

        public async ValueTask<bool> NotificationsAllowed()
        {
            _logger.LogInformation("NotificationsAllowed");
            return await _notificationApiInterop.HasPermissions();
        }

        public async Task RequestPermission()
        {
            _logger.LogInformation("RequestPermission");
            await _notificationApiInterop.AskForApproval();
        }

        public async Task ShowNotification(string title, string description, string iconurl)
        {
            await _notificationApiInterop.Notify(title, description, iconurl);
        }
    }
}
