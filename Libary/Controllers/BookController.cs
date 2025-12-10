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
        public ActionResult<Book> Get()
        {
            return Ok(_bookService.GetBooks());
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var b = _bookService.GetById(id);
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
        public ActionResult Post([FromBody] Book value)
        {
            if (_bookService.AddBook(value))
            {
                return Ok();
            }
            return NotFound();
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            var b = _bookService.UpdateBook(id, value.IsAvailable);
            if (b == null)
                return NotFound();
            return Ok(b);

        }

        // DELETE api/<LibaryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var b= _bookService.DeleteBook(id); 
            if(b == null)
                return NotFound();
            return Ok(b);
        }
    }
}
