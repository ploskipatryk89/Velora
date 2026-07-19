using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Application.Features.SchedulePayment.Dtos;

namespace Velora.Application.Features.SchedulePayment.Queries.GetAllSchedulePayments
{
    public class GetAllSchedulePaymentsQuery : IRequest<List<SchedulePaymentDto>>
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
      
    }
}
