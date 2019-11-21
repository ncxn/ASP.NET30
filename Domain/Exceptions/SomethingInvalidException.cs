using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class SomethingInvalidException : Exception
    {
        public SomethingInvalidException(string UserName, Exception ex)
        {
        }
    }
}
