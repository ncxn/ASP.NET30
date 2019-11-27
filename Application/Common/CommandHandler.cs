using Application.Interfaces;
using Domain.Commands;
using Domain.Bus;
using MediatR;
using Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        public CommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.Type, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())            
            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
