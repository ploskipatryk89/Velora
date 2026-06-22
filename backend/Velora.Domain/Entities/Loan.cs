using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Domain.Entities
{
    public class Loan : Payment
    {
        public LoanStatus Status { get; set; }

        public decimal? PrincipalAmount { get; set;}
        public decimal? RemainingBalance { get; set; }
        public DateOnly PaymentStartDate { get; set; }
        public DateOnly PaymentEndDate { get; set; } 

        public DateOnly? ContractStartDate { get; set; }
        public DateOnly? ContractEndDate { get; set; }
        public decimal? InterestRate { get; set; }

        private Loan()
        {

        }
        public Loan(string paymentName, string? description, string? paymentAccountNumber, decimal amount, Guid userId, Guid? bankAccountId,
            LoanStatus status, decimal? principalAmount, decimal? remainingBalance, DateOnly paymentStartDate, DateOnly paymentEndDate, 
            DateOnly? contractStartDate, DateOnly? contractEndDate, decimal? interestRate)
            :base(paymentName, description, paymentAccountNumber, amount, userId, bankAccountId)
        {
            Status = status;
            PrincipalAmount = principalAmount;
            RemainingBalance = remainingBalance;
            PaymentStartDate = paymentStartDate;
            PaymentEndDate = paymentEndDate;
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            InterestRate = interestRate;
            

        }
    }
}
