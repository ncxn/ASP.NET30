using System;
using System.Collections.Generic;
using MediatR;

namespace Domain.Events
{
    public abstract class Event : INotification, IRequest<bool>
    {
        public Guid Id { get; set; }
        public DateTime Created { get; private set; }
        public string Type { get; set; }
        public Dictionary<string, object> Args { get; private set; }
        protected Event()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            Type = GetType().Name;
            Args = new Dictionary<string, object>();
        }
        public abstract void Flatten();
    }
}
