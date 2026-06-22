using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Domain.Entities
{
     public class RecurringBill : Payment
    {
        public Frequency Frequency { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        

        private RecurringBill()
        {

        }
        public RecurringBill(string paymentName, string? description, string? paymentAccountNumber, decimal amount, Guid userId, Guid? bankAccountId,
            Frequency frequency, DateOnly startDate, DateOnly endDate
            )
            : base(paymentName, description, paymentAccountNumber, amount, userId, bankAccountId)
        {
            Frequency = frequency;
            StartDate = startDate;
            EndDate = endDate;
            

        }
    }
}
