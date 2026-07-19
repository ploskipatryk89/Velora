using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Application.Features.SchedulePayment.Dtos
{
    
    public class SchedulePaymentDto
    {
        public Guid Id { get; set; }
        public string PaymentName { get; set; }
        public DateOnly DueDate { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }

    }
}
