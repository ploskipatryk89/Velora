using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Velora.Domain.Exceptions.BankAccounts
{
    public class BankAccountNotFoundException : VeloraException
    {
        public Guid Id { get; }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        public BankAccountNotFoundException(Guid id) : base($"Nie znaleziono konta o identyfikatorze {id}")
        {
            Id = id;
        }

        
        


    }
}
