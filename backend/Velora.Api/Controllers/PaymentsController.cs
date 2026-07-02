using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Velora.Application.Features.Payments.Dtos;
using Velora.Application.Features.Payments.Queries.GetPaymentById;

namespace Velora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PaymentDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetPaymentByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
