using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Velora.Application.Features.BankAccounts.Commands.AddAccount;
using Velora.Application.Features.Loans.Commands.CreateLoan;
using Velora.Application.Features.Loans.Commands.DeleteLoan;

namespace Velora.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        
        public async Task<IActionResult> Create([FromBody] CreateLoanCommand command)
        {
            var loanId = await _mediator.Send(command);

            return Ok(loanId);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
           
            
                await _mediator.Send(new DeleteLoanCommand(id));
                return NoContent();
            
        }
    }
}
