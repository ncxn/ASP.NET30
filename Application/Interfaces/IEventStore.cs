using Domain.Events;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventStore
    {
        Task Save<T>(T theEvent) where T : Event;
    }
}
