using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Application.Features.RecurringBills.Commands.CreateRecurringBill
{
    public record CreateRecurringBillCommand
    (
        string PaymentName,
        string? Description,
        string? PaymentAccountNumber,
        decimal Amount,
        Guid BankAccountId,
        Frequency Frequency,
        DateOnly StartDate,
        DateOnly EndDate
  
    ) : IRequest<Guid>;
}
