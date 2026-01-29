using Library.Core.Services;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService Context)
        {
            _bookService = Context;
        }
        // GET: api/<LibaryController>
        [HttpGet]
        public async Task<ActionResult<Book>> Get()
        {
            return await Ok(_bookService.GetBooksAsync());
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var b =await _bookService.GetByIdAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            return Ok(b);
        }
        //[HttpGet("{name}")]
        //public Book Get(string nameBook)
        //{
        //    var book = books.FindIndex(b => b.Title == nameBook);
        //    return books[book];
        //}

        // POST api/<LibaryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book value)
        {
            if (await _bookService.AddBookAsync(value))
            {
                return Ok();
            }
            return NotFound();
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, bool isAvailable)
        {
            var b =await _bookService.UpdateBookAsync(id,isAvailable);
            if (b == null)
                return NotFound();
            return Ok(b);

        }

        // DELETE api/<LibaryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var b=await _bookService.DeleteBookAsync(id); 
            if(b == null)
                return NotFound();
            return Ok(b);
        }
    }
}
