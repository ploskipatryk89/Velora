
using Velora.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Auth
{
    public class PasswordHash : IPasswordHasher
    {
        private readonly PasswordHasher<User> _passwordHasher = new();
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
