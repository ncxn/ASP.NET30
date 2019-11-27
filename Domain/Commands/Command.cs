using FluentValidation.Results;
using MediatR;
using System;

namespace Domain.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public DateTime Created { get; private set; }
        public string Type { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
        protected Command()
        {
            Created = DateTime.Now;
            Type= GetType().Name;
        }
    }
}
