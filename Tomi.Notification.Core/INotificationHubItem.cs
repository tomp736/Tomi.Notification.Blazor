using System;

namespace Tomi.Notification.Core
{
    public interface INotificationHubItem
    {
        NotificationType NotificationType { get; set; }
        string NotifyTypeName { get; set; }

        string Title { get; set; }
        string Description { get; set; }
        string IconUrl { get; set; }
        DateTime NotificationDateTime { get; set; }
    }

    public enum NotificationType
    {
        User = 1,
        Group = 2,
        All = 3
    }
}
