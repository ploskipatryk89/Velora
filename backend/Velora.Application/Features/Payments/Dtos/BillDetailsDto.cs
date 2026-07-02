using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Payments.Dtos
{
    public class BillDetailsDto : PaymentDetailsDto
    {
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
