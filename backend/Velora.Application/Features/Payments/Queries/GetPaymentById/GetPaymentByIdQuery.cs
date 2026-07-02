using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Application.Features.Payments.Dtos;

namespace Velora.Application.Features.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<PaymentDetailsDto>
    {
        public Guid Id { get; set; }
        public GetPaymentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
