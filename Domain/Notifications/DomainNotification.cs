using System;
using Domain.Events;
using MediatR;

namespace Domain.Notifications
{
    public class DomainNotification : Event, IRequest<bool>, INotification
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
        public DomainNotification(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            Type = typeof(DomainNotification).Name;
        }
        public override void Flatten()
        {
            Args.Add("DomainNotificationId", Id);
            Args.Add("Key", Key);
            Args.Add("Value", Value);
            Args.Add("Version", Version);
        }
    }
}
