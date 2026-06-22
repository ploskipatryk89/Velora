using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore; // Wymagane dla metody FirstOrDefaultAsync() i AsNoTracking()
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions.Users;
using Velora.Infrastructure.Context; // Wymagane do wstrzyknięcia DbContextu

namespace Velora.Application.Features.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly VeloraDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(VeloraDbContext context, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Pobieramy użytkownika bezpośrednio z bazy danych bez śledzenia zmian (AsNoTracking)
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null)
            {
                throw new InvalidCredentialsException();
            }

            var isPasswordCorrect = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);

            if (!isPasswordCorrect)
            {
                throw new InvalidCredentialsException();
            }

            var token = _jwtProvider.GenerateAccessToken(user);

            return new LoginResponse
            {
                AccessToken = token
            };
        }
    }
}
