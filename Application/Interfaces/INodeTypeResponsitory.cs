using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INodeTypeResponsitory : IRepository<NodeType>
    {
        Task<bool> GetByType(string nodetype);
    }
}
