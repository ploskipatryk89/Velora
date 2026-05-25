using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace Velora.Domain.Exceptions.Users
{
    public class UserAlreadyExistsException : VeloraException
    {
        public string Email { get; set; }

        public UserAlreadyExistsException(string email) : base($"Użytkownik o tym emailu już istnieje")
        {
            Email = email;
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    }
}
