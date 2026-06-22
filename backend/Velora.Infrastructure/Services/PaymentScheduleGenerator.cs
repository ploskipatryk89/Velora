using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Enums;

namespace Velora.Infrastructure.Services
{
    public class PaymentScheduleGenerator : IPaymentScheduleGenerator
    {
        public ICollection<ScheduledPayment> Generate(Payment payment)
        {
            return payment switch
            {
                Bill bill => GenerateBillSchedule(bill),
                RecurringBill recurringBill => GenerateRecurringBillsSchedule(recurringBill),
                Loan loan => GenerateLoanSchedule(loan),
                _ => throw new NotSupportedException()
            };
        }

        private ICollection<ScheduledPayment> GenerateLoanSchedule(Loan loan)
        {
            var result = new List<ScheduledPayment>();

            var currentDate = loan.PaymentStartDate;

            while (currentDate <= loan.PaymentEndDate)
            {
                var dueDate = new DateOnly(
                    currentDate.Year,
                    currentDate.Month,
                    currentDate.Day
                    );

                result.Add(new ScheduledPayment
                {
                    PaymentId = loan.Id,
                    Amount = loan.Amount,
                    DueDate = dueDate,
                    Status = PaymentStatus.Unpaid
                });

                currentDate = currentDate.AddMonths(1);
            }

            return result;
                
        }

        private ICollection<ScheduledPayment> GenerateRecurringBillsSchedule(RecurringBill recurringBill)
        {
            var result = new List<ScheduledPayment>();

            var currentDate = recurringBill.StartDate;

            
            while (currentDate <= recurringBill.EndDate)
            {
                var dueDate = new DateOnly(
                    currentDate.Year,
                    currentDate.Month,
                    currentDate.Day);

                result.Add(new ScheduledPayment
                {
                    PaymentId = recurringBill.Id,
                    Amount = recurringBill.Amount,
                    DueDate = dueDate,
                    Status = PaymentStatus.Unpaid
                });

                currentDate = recurringBill.Frequency switch
                {
                    Frequency.Weekly => currentDate.AddDays(7),
                    Frequency.Monthly => currentDate.AddMonths(1),
                    Frequency.Quarterly => currentDate.AddMonths(3),
                    Frequency.Yearly => currentDate.AddYears(1),
                    _ => currentDate
                };

            }

            return result;

           
        }

        private ICollection<ScheduledPayment> GenerateBillSchedule(Bill bill)
        {
            return [
                new ScheduledPayment
                {
                    PaymentId = bill.Id,
                    Amount = bill.Amount,
                    DueDate = bill.DueDate,
                    Status = PaymentStatus.Unpaid
                }
                ];
        }
    }
}
