using Domain.Commands;
using System;

namespace Application.NodeTypes.CreateCommand
{
    public abstract class NodeTypeCreateCommand : Command
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Decs { get; set; }
    }
}
