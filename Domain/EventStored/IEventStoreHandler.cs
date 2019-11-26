using MediatR;
using System.Threading.Tasks;

namespace Domain.EventStored
{
    public interface IEventStoreHandler<in T> : INotificationHandler<T> where T : EventStore
    {
        void Save<T>(T theEvent) where T : EventStore;
    }
}
