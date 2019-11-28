using MediatR;
using System.Threading.Tasks;

namespace Domain.EventStore
{
    public interface IEventStoreHandler<T>: INotificationHandler<T> where T : EventStore
    {
        Task Save<E>(T theEvent) where E : EventStore;
    }
}
