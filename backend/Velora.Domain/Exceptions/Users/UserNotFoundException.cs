using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace Velora.Domain.Exceptions.Users
{
    public class UserNotFoundException : VeloraException
    {
        public string Email { get; }
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public UserNotFoundException(string email) : base($"Nie znaleziono użytkownika z emailem {email}")
        {
            Email = email;
        }
    }
}
