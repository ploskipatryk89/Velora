using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Application.Features.Payments.Dtos
{
    public class RecurringBillDetailsDto : PaymentDetailsDto
    {
        public decimal Amount { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public Frequency Frequency { get; set; }
    }
}
