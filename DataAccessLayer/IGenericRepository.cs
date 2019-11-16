using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IGenericRepository<T> where T : class
    {
        IDbConnection GetOpenConnection();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(object id);
        void InsertAsync(T entity);
        void DeleteAsync(object id);
        void UpdateAsync(T entity);
    }
}
