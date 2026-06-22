using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.BankAccounts.Commands.UpdateAccount
{
    public record UpdateAccountCommand
    (
        Guid id,
        string bankName,
        string bankAccountNumber,
        decimal balance

      
    ) : IRequest<Unit>;
    
}
