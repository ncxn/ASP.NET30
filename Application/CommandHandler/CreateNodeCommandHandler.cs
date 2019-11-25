using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Command;
using Application.Interfaces;
using MediatR;

namespace Application.CommandHandler
{
    public class CreateNodeCommandHandler : IRequestHandler<CreateNodeCommand, bool>
    {
        private readonly INodeResponsitory<Node> _nodeResponsitory;

        public CreateNodeCommandHandler(INodeResponsitory<Node> nodeResponsitory)
        {
            _nodeResponsitory = nodeResponsitory;
        }

        public async Task<bool> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
        {
            var Node = new Node
            {
                Id = request.Id,
                Title=request.Title,
                Content = request.Content,
                Url = request.Url,
            };
            await _nodeResponsitory.Creare(Node);
            return true;
        }
    }
}
