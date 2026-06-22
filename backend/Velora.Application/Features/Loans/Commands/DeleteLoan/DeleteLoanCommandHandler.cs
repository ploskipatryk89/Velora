using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.Loans.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly VeloraDbContext _context;
        private readonly ICurrentUser _currentUser;

        public DeleteLoanCommandHandler(VeloraDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

            var loan = await _context.Loans
                 .FirstOrDefaultAsync(l => l.Id == request.LoanId && l.UserId == currentUserId);

            if (loan == null)
            {
                throw new LoanNotFoundException(request.LoanId);
            }

            _context.Loans.Remove(loan);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
