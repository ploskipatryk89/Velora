using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.BankAccounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<Unit>
    {
        public Guid BankAccountId { get; set; }

        public DeleteAccountCommand(Guid bankAccountId)
        {
            BankAccountId = bankAccountId;
        }
    }
}
