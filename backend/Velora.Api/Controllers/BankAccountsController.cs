using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Velora.Application.Features.BankAccounts.Commands;
using Velora.Application.Features.BankAccounts.Commands.AddAccount;
using Velora.Application.Features.BankAccounts.Commands.DeleteAccount;
using Velora.Application.Features.BankAccounts.Commands.UpdateAccount;
using Velora.Application.Features.BankAccounts.Dtos;
using Velora.Application.Features.BankAccounts.Queries.GetAllBankAccounts;
using Velora.Domain.Exceptions.BankAccounts;

namespace Velora.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Guid) , StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddBankAccountCommand command)
        {
            var bankAccountId = await _mediator.Send(command);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAccountCommand(id);

            try
            {
                await _mediator.Send(command);
                return NoContent();
            } catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAccountCommand command)
        {
            if (id != command.id)
            {
                return BadRequest(new { message = "Id w URL rozni sie od ID w body" });
            }

            try
            {
                await _mediator.Send(command);
                return NoContent();
            } catch(BankAccountNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(List<BankAccountDto>) , StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBankAccountsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }


    }
}
