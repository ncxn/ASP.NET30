using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Node.NodeCreate
{
    public abstract class NodeCreateCommand:Command
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
    }
}
