using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace DataAccessLayer
{
    public class NodeRepository : INodeResponsitory<Node>
    {
        public Task<Node> Creare(Node entity)
        {
            //fake to test
            var rs= new Node
            {
                Id ="0",
                Title="Thử nghiệm",
                Content ="Nội dung thử nghiệm",
                Url="/docs/node/0"
            };
            return Task.FromResult(rs);
            //return rs;
        }

        public Task<Node> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Node> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Node>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Node>> ReadOnlyGetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Node> Update(Node entity)
        {
            throw new NotImplementedException();
        }
    }
}
