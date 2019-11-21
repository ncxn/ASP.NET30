using System.Collections.Generic;

namespace Domain.Entities
{
    public class NodeType
    {
        public NodeType()
        {
            Nodes = new HashSet<Node>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string Decs { get; set; }
        public string Url { get; set; }
        public ICollection<Node> Nodes { get; set; }
       
    }
}
