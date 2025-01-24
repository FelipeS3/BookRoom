using System.Runtime.CompilerServices;
using BookRoom.Application.Commands.CreateLoan;
using BookRoom.Application.Commands.DeleteLoan;
using BookRoom.Application.Commands.UpdateLoan;
using BookRoom.Application.Queries.GetAllLoans;
using BookRoom.Application.Queries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRoom.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllLoansQuery = new GetAllLoansQuery();

            var loan = await _mediator.Send(getAllLoansQuery);

            return Ok(loan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetLoanByIdQuery(id);

            var loan = await _mediator.Send(query);

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLoanCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLoanCommand(id);

            var loan = await _mediator.Send(command);

            return NoContent();
        }

    }
}
