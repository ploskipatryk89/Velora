using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Domain.Entities
{
    public class Bill : Payment
    {
        public DateOnly DueDate { get; set; }

        public Bill(string paymentName, string? description, string? paymentAccountNumber, decimal amount, Guid userId, Guid? bankAccountId, DateOnly dueDate
            
            )
            : base(paymentName, description, paymentAccountNumber, amount, userId, bankAccountId)
        {
            DueDate = dueDate;
            

        }
    }
}
