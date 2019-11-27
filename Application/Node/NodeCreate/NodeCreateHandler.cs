using Application.Common;
using Application.Interfaces;
using Domain.Bus;
using Domain.Entities;
using Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Node.NodeCreate
{
    public class NodeCreateHandler : CommandHandler, IRequestHandler<NodeCreateCommand, bool>
    {
        private readonly INodeResponsitory NodeResponsitory;
        private readonly IMediatorHandler Bus;
        public NodeCreateHandler(INodeResponsitory nodeResponsitory, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            NodeResponsitory = nodeResponsitory;
            Bus = bus;
        }
        public async Task<bool> Handle(NodeCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return await Task.FromResult(false);
            }

            var Model = new NodeModel(request.Id, request.Title, request.Content, request.Url, request.Url);

            if (await NodeResponsitory.Creare(Model))
                await Bus.RaiseEvent(new DomainNotification(request.Type, "Dữ liệu đã có loại này!"));
            return await Task.FromResult(true);
        }
    }
}
