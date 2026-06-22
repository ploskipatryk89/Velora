using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Velora.Domain.Exceptions
{
    public class LoanNotFoundException : VeloraException
    {
        public Guid Id { get; }
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public LoanNotFoundException(Guid id) : base($"Nie znaleziono konta o id: {id}")
        {
            Id = id;
        }
    }
}
