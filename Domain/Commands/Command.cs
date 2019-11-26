using FluentValidation.Results;
using MediatR;
using System;

namespace Domain.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
