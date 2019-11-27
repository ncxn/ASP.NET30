using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class EventStore
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string User { get; set; }
    }
}
