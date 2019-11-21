using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;
        public EventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task RaiseEvent<T>(T @event) where T : DomainEvent
        {
            return _mediator.Publish(@event);
        }
    }
}
