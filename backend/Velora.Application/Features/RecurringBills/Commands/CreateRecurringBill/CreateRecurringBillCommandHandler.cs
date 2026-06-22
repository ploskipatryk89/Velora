using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions.BankAccounts;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.RecurringBills.Commands.CreateRecurringBill
{
    public class CreateRecurringBillCommandHandler : IRequestHandler<CreateRecurringBillCommand, Guid>
    {
        private readonly ICurrentUser _currentUser;
        private readonly VeloraDbContext _context;
        private readonly IPaymentScheduleGenerator _paymentScheduleGenerator;

        public CreateRecurringBillCommandHandler(ICurrentUser currentUser, VeloraDbContext context, IPaymentScheduleGenerator paymentScheduleGenerator)
        {
            _currentUser = currentUser;
            _context = context;
            _paymentScheduleGenerator = paymentScheduleGenerator;
        }

        public async Task<Guid> Handle(CreateRecurringBillCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

            var newRecurringBill = new RecurringBill(request.PaymentName, request.Description, request.PaymentAccountNumber,
                request.Amount, currentUserId, request.BankAccountId, request.Frequency, request.StartDate, request.EndDate);

            var bankAccountExists = await _context.BankAccounts
                .AnyAsync(b => b.Id == request.BankAccountId && b.UserId == currentUserId);

            if (!bankAccountExists)
            {
                throw new BankAccountNotFoundException(request.BankAccountId);
            }

            _context.RecurringBills.Add(newRecurringBill);

            var schedulePayments = _paymentScheduleGenerator.Generate(newRecurringBill);

            
            _context.ScheduledPayments.AddRange(schedulePayments);

            await _context.SaveChangesAsync(cancellationToken);

            return newRecurringBill.Id;
        }
    }
}
