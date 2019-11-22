using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Events;

namespace Domain.Notification
{
    public class DomainNotificationHandler: IEventHandler<DomainNotification>
    {
        public ReadOnlyCollection<DomainNotification> Notifications => _notifications.AsReadOnly();
        private List<DomainNotification> _notifications;
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }
        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }
        public virtual bool HasNotifications()
        {
            return Notifications.Count <= 0;
        }
        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
