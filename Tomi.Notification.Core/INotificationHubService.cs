using System.Threading.Tasks;

namespace Tomi.Notification.Core
{
    public interface INotificationHubService
    {
        Task ReceivePermissionRequest();
        Task ReceiveNotification(string title, string description, string iconurl);
    }
}
