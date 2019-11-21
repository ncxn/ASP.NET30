using System.Threading.Tasks;

namespace Domain.Events
{
    public interface IEventDispatcher
    {
        Task RaiseEvent<T>(T @event) where T : DomainEvent;
    }
}
