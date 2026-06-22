using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions.BankAccounts;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.Loans.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly VeloraDbContext _context;
            private readonly ICurrentUser _currentUser;
        private readonly IPaymentScheduleGenerator _paymentScheduleGenerator;

        public CreateLoanCommandHandler(VeloraDbContext context, ICurrentUser currentUser, IPaymentScheduleGenerator paymentScheduleGenerator)
        {
            _context = context;
            _currentUser = currentUser;
            _paymentScheduleGenerator = paymentScheduleGenerator;
        }

        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

          

            var newLoan = new Loan(request.CreditorName, request.Description, request.CreditorAccountNumber, request.Installment,
                                    currentUserId, request.BankAccountId, request.Status, request.PrincipalAmount, request.RemainingBalance,
                                    request.PaymentStartDate, request.PaymentEndDate, request.ContractStartDate, request.ContractEndDate, request.InterestRate);

            var bankAccountExists = await _context.BankAccounts
                 .AnyAsync(b => b.Id == request.BankAccountId && b.UserId == currentUserId);

            if (!bankAccountExists)
            {
                throw new BankAccountNotFoundException(request.BankAccountId);
            }


             _context.Loans.Add(newLoan);

            var scheduledPayments = _paymentScheduleGenerator.Generate(newLoan);

            _context.ScheduledPayments.AddRange(scheduledPayments);

           await _context.SaveChangesAsync(cancellationToken);

            return newLoan.Id;

        }
    }
}
