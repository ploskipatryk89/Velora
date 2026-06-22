using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions.BankAccounts;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.Bills.Commands.CreateBill
{
    public class CreateBillCommandHandler : IRequestHandler<CreateBillCommand, Guid>
    {
        private readonly ICurrentUser _currentUser;
        private readonly VeloraDbContext _context;
        private readonly IPaymentScheduleGenerator _paymentScheduleGenerator;

        public CreateBillCommandHandler(ICurrentUser currentUser, VeloraDbContext context, IPaymentScheduleGenerator paymentScheduleGenerator)
        {
            _currentUser = currentUser;
            _context = context;
            _paymentScheduleGenerator = paymentScheduleGenerator;
        }

        public async Task<Guid> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

            var newBill = new Bill(request.PaymentName, request.Description, request.PaymentAccountNumber, request.Amount, currentUserId, request.BankAccountId, request.DueDate);

            var bankAccountExists = await _context.BankAccounts
                .AnyAsync(b => b.Id == request.BankAccountId && b.UserId == currentUserId);

            if (!bankAccountExists)
            {
                throw new BankAccountNotFoundException(request.BankAccountId);
            }

            _context.Bills.Add(newBill);

            var schedulePayments = _paymentScheduleGenerator.Generate(newBill);

            _context.ScheduledPayments.AddRange(schedulePayments);

            await _context.SaveChangesAsync();

            return newBill.Id;
        }
    }
}
