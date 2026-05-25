using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Velora.Domain.Exceptions
{
    public abstract class VeloraException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public VeloraException(string message) : base(message)
        {

        }
    }
}
