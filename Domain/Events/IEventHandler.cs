using MediatR;

namespace Domain.Events
{
    public interface IEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
    }
}
