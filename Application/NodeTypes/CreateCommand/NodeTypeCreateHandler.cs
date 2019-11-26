using Application.Common;
using Application.Interfaces;
using Domain.Commands;
using Domain.Entities;
using Domain.Notification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NodeTypes.CreateCommand
{
    public class NodeTypeCreateHandler : CommandHandler, IRequestHandler<NodeTypeCreateCommand, bool>
    {
        private readonly INodeTypeResponsitory NodeTypeResponsitory;
        private readonly IMediatorHandler Bus;
        public NodeTypeCreateHandler(INodeTypeResponsitory nodeTypeResponsitory, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            NodeTypeResponsitory = nodeTypeResponsitory;
            Bus = bus;
        }

        public Task<bool> Handle(NodeTypeCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var Model = new NodeType(Guid.NewGuid(), request.Type, request.Decs);
            
            if (NodeTypeResponsitory.GetByType(Model.Type) != null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "Dữ liệu đã có loại này!"));
                return Task.FromResult(false);
            }

            NodeTypeResponsitory.Creare(Model);

            if (Commit())
            {
                //Raise Event for Node type created
                //Bus.RaiseEvent(@event);
            }
            return Task.FromResult(true);
        }
    }
}
