using Library.Core.Services;
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
        public IEnumerable<Book> Get()
        {
            return _bookService.GetBooks();
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            var index= _bookService.GetBooks().FindIndex(x => x.Id==id);
            return _bookService.GetBooks()[index];
        }
        //[HttpGet("{name}")]
        //public Book Get(string nameBook)
        //{
        //    var book = books.FindIndex(b => b.Title == nameBook);
        //    return books[book];
        //}

        // POST api/<LibaryController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            _bookService.GetBooks().Add(value);
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            var index = _bookService.GetBooks().FindIndex(x => x.Id == id);
            _bookService.GetBooks()[index].Genre = value.Genre;
            _bookService.GetBooks()[index].IsAvailable = value.IsAvailable;
            //לסיים לפי עדכון
            
        }

            // DELETE api/<LibaryController>/5
            [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var index = _bookService.GetBooks().Find(x => x.Id == id);
            _bookService.GetBooks().Remove(index);
        }
    }
}
