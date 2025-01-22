using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRoom.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }


    }
}
