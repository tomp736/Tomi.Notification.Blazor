using System;
using System.Collections.Generic;
using Tomi.Notification.Core;

namespace Tomi.Notification.AspNetCore
{
    public interface INotificationProcessingServiceDataProvider
    {
        IEnumerable<INotificationItem> GetNotificationItems(DateTime notificationDateTime);
    }
}
