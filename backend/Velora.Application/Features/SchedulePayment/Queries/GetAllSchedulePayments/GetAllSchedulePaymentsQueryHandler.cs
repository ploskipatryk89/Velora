using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Application.Features.SchedulePayment.Dtos;
using Velora.Domain.Abstractions;
using Velora.Infrastructure.Context;

namespace Velora.Application.Features.SchedulePayment.Queries.GetAllSchedulePayments
{
    public class GetAllSchedulePaymentsQueryHandler : IRequestHandler<GetAllSchedulePaymentsQuery, List<SchedulePaymentDto>>
    {
        private readonly VeloraDbContext _context;
        private readonly ICurrentUser _currentUser;

        public GetAllSchedulePaymentsQueryHandler(VeloraDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<List<SchedulePaymentDto>> Handle(GetAllSchedulePaymentsQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _currentUser.GetCurrentUser();

            var targetMonth = request.Month ?? DateTime.Today.Month;
            var targetYear = request.Year ?? DateTime.Today.Year;

            var startDate = new DateOnly(targetYear, targetMonth, 1);
            var endDate = startDate.AddMonths(1);


            

            

            var schedulePayments = await _context.ScheduledPayments
                .Include(s => s.Payment)
                .Where(s => s.Payment.UserId == currentUser
                        && s.DueDate >= startDate
                        && s.DueDate < endDate)
                .Select(s => new SchedulePaymentDto
                {
                    Id = s.Id,
                    PaymentName = s.Payment.PaymentName,
                    DueDate = s.DueDate,
                    Status = s.Status,
                    Amount = s.Amount

                })
                .ToListAsync();

            return schedulePayments;
        }
    }
}
