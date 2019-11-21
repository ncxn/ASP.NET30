using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public interface IEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
    }
}
