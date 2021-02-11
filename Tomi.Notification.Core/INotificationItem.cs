using System;

namespace Tomi.Notification.Core
{
    public interface INotificationItem
    {
        string Title { get; set; }
        string Description { get; set; }
        string IconUrl { get; set; }
        DateTime NotificationDateTime { get; set; }
    }
}
