using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<IEnumerable<T>> ReadOnlyGetAll();
        Task<T> Creare(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
