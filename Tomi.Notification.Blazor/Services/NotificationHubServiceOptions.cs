using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Tomi.Notification.Blazor.Services
{
    public class NotificationHubServiceOptions
    {
        public readonly IServiceCollection Services;
        public NotificationHubServiceOptions(IServiceCollection serviceCollection)
        {
            serviceCollection = Services;
        }

        public Uri Uri { get; set; }
        public Func<Task<string>> AccessTokenProvider { get; set; }
        public IRetryPolicy RetryPolicy { get; set; }
    }
}
