using Domain.Bus;
using Domain.Commands;
using Domain.Events;
using Domain.EventStored;
using Domain.Notifications;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Application.Common
{
    public sealed class CommandBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStoreHandler _eventStore;

        public CommandBus(IMediator mediator, EventStored.IEventStoreHandler eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

       
        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.Type.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
