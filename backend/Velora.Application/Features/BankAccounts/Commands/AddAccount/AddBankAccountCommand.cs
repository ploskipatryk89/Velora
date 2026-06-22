using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.BankAccounts.Commands.AddAccount
{
    public record AddBankAccountCommand
    (
        string BankName,
        string BankAccountNumber,
        decimal Balance

       
    ) : IRequest<Guid>;
}
