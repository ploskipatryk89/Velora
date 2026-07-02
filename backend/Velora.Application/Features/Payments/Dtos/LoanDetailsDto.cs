using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Application.Features.Payments.Dtos
{
    public class LoanDetailsDto : PaymentDetailsDto
    {
        public decimal Instalment { get; set; }
        public decimal? PrincipalAmount { get; set; }
        public decimal? RemainingBalance { get; set; }
        public DateOnly PaymentStartDate { get; set; }
        public DateOnly PaymentEndDate { get; set; }
        public DateOnly? ContractStartDate { get; set; }
        public DateOnly? ContractEndDate { get; set; }
        public decimal? InterestRate { get; set; }

        public LoanStatus Status { get; set; }
    }
}
