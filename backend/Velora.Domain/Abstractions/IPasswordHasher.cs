using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Domain.Abstractions
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string PasswordHash);
    }
}
