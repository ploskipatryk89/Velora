using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Bills.Commands.CreateBill
{
    public record CreateBillCommand
    (
        string PaymentName,
        string? Description,
        string? PaymentAccountNumber,
        decimal Amount,
        DateOnly DueDate,
        Guid BankAccountId
    ) : IRequest<Guid>
    {
        
    };
    
}
