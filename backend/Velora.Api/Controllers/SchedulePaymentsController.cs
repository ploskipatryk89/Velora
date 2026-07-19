using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Velora.Application.Features.SchedulePayment.Dtos;
using Velora.Application.Features.SchedulePayment.Queries.GetAllSchedulePayments;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Velora.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulePaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchedulePaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(List<SchedulePaymentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSchedulePaymentsQuery query)
        {
            // Ponieważ query jest teraz parametrem metody, ASP.NET Core automatycznie
            // zmapuje przesłane w URL zmienne 'month' i 'year' na właściwości w Twojej klasie.

            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
