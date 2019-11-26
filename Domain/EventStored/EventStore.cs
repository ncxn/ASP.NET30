using Domain.Events;
using MediatR;
using System;

namespace Domain.EventStored
{
    public class EventStore : INotification, IRequest<bool>
    {
        public EventStore(Events.EventStore theEvent, string content, string user)
        {
            Id = Guid.NewGuid();
            Content = content;
            User = user;
        }

        // Database Constructor
        protected EventStore() { }
        public Guid Id { get; private set; }
        public string Content { get; set; }
        public string User { get; private set; }
    }
}
