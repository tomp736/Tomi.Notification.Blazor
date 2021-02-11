using System.Threading.Tasks;

namespace Tomi.Notification.Core
{
    public interface INotificationClient
    {
        Task ReceivePermissionRequest();
        Task ReceiveNotification(string title, string description, string iconurl);
    }
}
