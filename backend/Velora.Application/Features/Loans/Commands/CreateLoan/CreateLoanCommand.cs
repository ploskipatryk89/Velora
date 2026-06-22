using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Application.Features.Loans.Commands.CreateLoan
{
    public record CreateLoanCommand
    (
        string CreditorName,
        string? CreditorAccountNumber,
        string? Description,
      LoanStatus Status,

      decimal Installment,
    decimal? PrincipalAmount,
    decimal? RemainingBalance,
    DateOnly PaymentStartDate,
    DateOnly PaymentEndDate,

    DateOnly? ContractStartDate,
    DateOnly? ContractEndDate,
    decimal? InterestRate,
   
    Guid BankAccountId
    ) : IRequest<Guid>;
}
