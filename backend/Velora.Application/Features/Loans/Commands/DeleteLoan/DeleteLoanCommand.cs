using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Loans.Commands.DeleteLoan
{
    public record DeleteLoanCommand(Guid LoanId) : IRequest<Unit>;
    
    
}
