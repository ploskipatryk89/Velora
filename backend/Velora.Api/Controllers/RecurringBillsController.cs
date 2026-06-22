using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Velora.Application.Features.Bills.Commands.CreateBill;
using Velora.Application.Features.RecurringBills.Commands.CreateRecurringBill;

namespace Velora.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecurringBillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecurringBillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Create([FromBody] CreateRecurringBillCommand command)
        {
            var recurringBillId = await _mediator.Send(command);

            return Ok(recurringBillId);
        }
    }
}
