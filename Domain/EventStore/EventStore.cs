using Domain.Events;
using MediatR;
using System;

namespace Domain.EventStore
{
    public class EventStore : Event, INotification, IRequest<bool>
    {
        public EventStore(Event @event, string content, string user)
        {
            Id = Guid.NewGuid();
            Content = content;
            User = user;
        }

        // Database Constructor
        protected EventStore() { }
        //public Guid Id { get; private set; }
        public string Content { get; set; }
        public string User { get; private set; }

        public override void Flatten()
        {
            throw new NotImplementedException();
        }
    }
}
