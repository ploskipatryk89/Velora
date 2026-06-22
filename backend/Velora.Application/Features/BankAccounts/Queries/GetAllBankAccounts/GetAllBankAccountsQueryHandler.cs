using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Application.Features.BankAccounts.Dtos;
using Velora.Domain.Abstractions;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.BankAccounts.Queries.GetAllBankAccounts
{
   
    public class GetAllBankAccountsQueryHandler : IRequestHandler<GetAllBankAccountsQuery, List<BankAccountDto>>
    {
        private readonly VeloraDbContext _context;
        private readonly ICurrentUser _currentUser;

        public GetAllBankAccountsQueryHandler(VeloraDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<List<BankAccountDto>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

            var bankAccounts = await _context.BankAccounts
                .AsNoTracking()
                .Where(b => b.UserId == currentUserId)
                .OrderBy(b => b.BankName)
                .Select(b => new BankAccountDto
                {
                    Id = b.Id,
                    Name = b.BankName,
                    AccountNumber = b.BankAccountNumber,
                    Balance = b.Balance
                })
                .ToListAsync(cancellationToken);


            return bankAccounts;
        }
    }
}
