using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Velora.Domain.Exceptions.Users
{
    public class InvalidCredentialsException : VeloraException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public InvalidCredentialsException() : base("Nieprawidłowy email lub hasło")
        {

        }
    }
}
