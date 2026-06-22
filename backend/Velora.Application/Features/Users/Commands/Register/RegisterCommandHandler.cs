using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore; // Wymagane dla metody AnyAsync()
using System.Threading;
using System.Threading.Tasks;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions.Users;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly VeloraDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(VeloraDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // 1. Sprawdzenie, czy użytkownik z takim mailem już istnieje w bazie (zamiast starego repo)
            var emailExists = await _context.Users
                .AnyAsync(u => u.Email == request.Email, cancellationToken);

            if (emailExists)
            {
                // Tutaj rzucasz swój dedykowany wyjątek domenowy
                throw new UserAlreadyExistsException(request.Email);
            }

            // 2. Mapowanie komendy na encję User przy użyciu Mapstera
            var user = request.Adapt<User>();

            // 3. Hashowanie hasła
            user.PasswordHash = _passwordHasher.HashPassword(request.Password);

            // 4. Dodanie użytkownika do kontekstu bazy danych
            _context.Users.Add(user);

            // 5. Zapis zmian w bazie (zastępuje metodę Commit z UnitOfWork)
            await _context.SaveChangesAsync(cancellationToken);

            // 6. Zwrócenie odpowiedzi
            return new RegisterResponse(user.Id, user.Email);
        }
    }
}
