using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.BankAccounts.Commands.AddAccount
{
    public class AddBankAccountCommandHandler : IRequestHandler<AddBankAccountCommand, Guid>
    {
        private readonly ICurrentUser _currentUser;
        private readonly VeloraDbContext _context;

        public AddBankAccountCommandHandler(ICurrentUser currentUser, VeloraDbContext context)
        {
            _currentUser = currentUser;
            _context = context;
        }

        public async Task<Guid> Handle(AddBankAccountCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();


         
            var newBankAccount = new BankAccount(request.BankName, request.BankAccountNumber, request.Balance, currentUserId);

            _context.BankAccounts.Add(newBankAccount);
            await _context.SaveChangesAsync(cancellationToken);

            return newBankAccount.Id;
            
        }
    }
}
