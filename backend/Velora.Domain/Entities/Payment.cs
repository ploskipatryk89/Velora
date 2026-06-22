using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public string PaymentName { get; set; }
        public string? Description { get; set; }
        public string? PaymentAccountNumber { get; set; }
        public decimal Amount { get; set; }

        //Foreighn keys
        public Guid UserId { get; set; }
        public User User { get; set; }
        

        public Guid? BankAccountId { get; set; }
        public BankAccount? BankAccount { get; set; }

        public ICollection<ScheduledPayment> ScheduledPayments { get; set; }

        protected Payment()
        {

        }
        protected Payment(string paymentName, string? description, string? paymentAccountNumber, decimal amount, Guid userId, Guid? bankAccountId)
        {
            PaymentName = paymentName;
            Description = description;
            PaymentAccountNumber = paymentAccountNumber;
            Amount = amount;
            UserId = userId;
            BankAccountId = bankAccountId;
        }


    }
}
