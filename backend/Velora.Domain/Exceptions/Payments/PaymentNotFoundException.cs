using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Velora.Domain.Exceptions.Payments
{
    public class PaymentNotFoundException : VeloraException
    {
        public Guid Id { get; }
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public PaymentNotFoundException(Guid id) : base($"Nie znaleziono platnosci o id: {id}")
        {
            Id = id;
        }
    }
}
