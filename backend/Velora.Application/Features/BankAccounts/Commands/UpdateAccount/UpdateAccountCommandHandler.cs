using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Exceptions.BankAccounts;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.BankAccounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
    {
        private readonly VeloraDbContext _context;
        private readonly ICurrentUser _currentUser;

        public UpdateAccountCommandHandler(VeloraDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

            var bankAccount = await _context.BankAccounts.FirstOrDefaultAsync(b => b.Id == request.id && b.UserId == currentUserId, cancellationToken);

            if (bankAccount == null)
            {
                throw new BankAccountNotFoundException(request.id);
            }

            if (request.bankName != bankAccount.BankName)
            {
                bankAccount.BankName = request.bankName;
            }

            if (request.bankAccountNumber != bankAccount.BankAccountNumber)
            {
                bankAccount.BankAccountNumber = request.bankAccountNumber;
            }

            if (request.balance != bankAccount.Balance)
            {
                bankAccount.Balance = request.balance;
            }

            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
