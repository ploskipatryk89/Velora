using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Application.Features.BankAccounts.Dtos;

namespace Velora.Application.Features.BankAccounts.Queries.GetAllBankAccounts
{
    public record GetAllBankAccountsQuery : IRequest<List<BankAccountDto>>
    {
    }
}
