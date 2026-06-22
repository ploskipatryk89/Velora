using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Exceptions.BankAccounts;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.BankAccounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly ICurrentUser _currentUser;
        private readonly VeloraDbContext _context;

        public DeleteAccountCommandHandler(ICurrentUser currentUser, VeloraDbContext context)
        {
            _currentUser = currentUser;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

            if (currentUserId == null)
            {
                throw new UnauthorizedAccessException("Brak autoryzacji");
            }

            var bankAccount = await _context.BankAccounts
                 .FirstOrDefaultAsync(b => b.Id == request.BankAccountId && b.UserId == currentUserId);

            if (bankAccount == null)
            {
                throw new BankAccountNotFoundException(request.BankAccountId);
            }

            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
