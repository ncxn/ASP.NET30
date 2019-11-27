using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventStoreResponsitory<T> where T : class
    {
        Task<bool> Save(T @eventstore);
    }
}