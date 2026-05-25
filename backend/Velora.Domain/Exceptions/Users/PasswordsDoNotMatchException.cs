using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Velora.Domain.Exceptions.Users
{
    public class PasswordsDoNotMatchException : VeloraException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public PasswordsDoNotMatchException() : base("Hasła mie są takie same")
        {

        }
    }
}
