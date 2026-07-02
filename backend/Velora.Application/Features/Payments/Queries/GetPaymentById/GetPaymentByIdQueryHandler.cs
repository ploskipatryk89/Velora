using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Application.Features.Payments.Dtos;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions.Payments;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDetailsDto>
    {
        private readonly VeloraDbContext _context;
        private readonly ICurrentUser _currentUser;

        public GetPaymentByIdQueryHandler(VeloraDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<PaymentDetailsDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUser.GetCurrentUser();

            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == request.Id && p.UserId == currentUserId);

            if (payment == null)
            {
                throw new PaymentNotFoundException(request.Id);
            }

            return payment switch
            {
                Loan loan => new LoanDetailsDto
                {
                    Id = loan.Id,
                    PaymentName = loan.PaymentName,
                    Description = loan.Description,
                    PaymentAccountNumber = loan.PaymentAccountNumber,
                    BankAccountId = loan.BankAccountId,
                    TypPlatnosci = "Kredyt",
                    Instalment = loan.Amount,
                    InterestRate = loan.InterestRate,
                    PrincipalAmount = loan.PrincipalAmount,
                    RemainingBalance = loan.RemainingBalance,
                    PaymentStartDate = loan.PaymentStartDate,
                    PaymentEndDate = loan.PaymentEndDate,
                    ContractStartDate = loan.ContractStartDate,
                    ContractEndDate = loan.ContractEndDate,
                    Status = loan.Status

                },
                Bill bill => new BillDetailsDto
                {
                    Id = bill.Id,
                    PaymentName = bill.PaymentName,
                    Description = bill.Description,
                    PaymentAccountNumber = bill.PaymentAccountNumber,
                    BankAccountId = bill.BankAccountId,
                    TypPlatnosci = "Rachunek jednorazowy",
                    DueDate = bill.DueDate,
                    Amount = bill.Amount
                },
                RecurringBill recurringBill => new RecurringBillDetailsDto
                {
                    Id = recurringBill.Id,
                    PaymentName = recurringBill.PaymentName,
                    Description = recurringBill.Description,
                    PaymentAccountNumber = recurringBill.PaymentAccountNumber,
                    BankAccountId = recurringBill.BankAccountId,
                    TypPlatnosci = "Rachunek cykliczny",
                    StartDate = recurringBill.StartDate,
                    EndDate = recurringBill.EndDate,
                    Frequency = recurringBill.Frequency
                },
                _ => new PaymentDetailsDto
                {
                    Id = payment.Id,
                    PaymentName = payment.PaymentName,
                    PaymentAccountNumber = payment.PaymentAccountNumber
                }


            };
        }
    }
}
