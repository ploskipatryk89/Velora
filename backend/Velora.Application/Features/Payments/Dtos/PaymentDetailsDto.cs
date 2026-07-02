using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Payments.Dtos
{
    public class PaymentDetailsDto
    {
        public Guid Id { get; set; }
        public string PaymentName { get; set; }
        public string? Description { get; set; }
        public string? PaymentAccountNumber { get; set; }
        public Guid? BankAccountId { get; set; }
        public string TypPlatnosci { get; set; }
    }
}
