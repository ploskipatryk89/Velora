using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.BankAccounts.Dtos
{
    public class BankAccountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
