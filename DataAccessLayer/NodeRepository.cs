using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace DataAccessLayer
{
    public class NodeRepository : INodeResponsitory
    {
        public Task<bool> Creare(NodeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NodeModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<NodeModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NodeModel>> ReadOnlyGetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(NodeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
