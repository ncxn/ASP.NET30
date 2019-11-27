using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<IEnumerable<T>> ReadOnlyGetAll();
        Task<bool> Creare(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
