using Domain.Entities;
using MediatR;

namespace Application.Command
{
    public class CreateNodeCommand: Node, IRequest<bool>
    {
        
    }
}
