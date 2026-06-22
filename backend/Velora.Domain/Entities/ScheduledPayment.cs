using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Domain.Entities
{
    public class ScheduledPayment : Entity
    {
        public DateOnly DueDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateOnly? PaidDate { get; set; } 

        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }

       

    }
}
