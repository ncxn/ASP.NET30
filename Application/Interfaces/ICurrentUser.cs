using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ICurrentUser
    {
        public string UserId { get; }
        public string UserName { get; }
        public string Email { get; }
    }
}
