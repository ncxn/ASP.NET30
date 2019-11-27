using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class NodeType 
    {
        public NodeType()
        {
            Nodes = new HashSet<NodeModel>();
        }

        public NodeType(Guid id, string type, string decs)
        {
            Id = id;
            Type = type;
            Decs = decs;
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Decs { get; set; }
        public string Url { get; set; }
        public ICollection<NodeModel> Nodes { get; set; }
 
    }
}
