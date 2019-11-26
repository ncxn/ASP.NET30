using MediatR;

namespace Domain.Events
{
    public interface IEventHandler<in T> : INotificationHandler<T> where T : Event
    {
    }
}
