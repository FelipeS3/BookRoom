using BookRoom.Application.Commands.CreateBook;
using BookRoom.Application.Commands.DeleteBook;
using BookRoom.Application.Commands.UpdateBook;
using BookRoom.Application.Commands.UpdateBookPartial;
using BookRoom.Application.Queries.GetAllBooks;
using BookRoom.Application.Queries.GetBookById;
using BookRoom.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRoom.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllBooksQuery = new GetAllBooksQuery();

            var books = await _mediator.Send(getAllBooksQuery);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getBooksById = new GetBookByIdQuery(id);

            var books = await _mediator.Send(getBooksById);

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdateBookPartialCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
//BookRoomDbContext