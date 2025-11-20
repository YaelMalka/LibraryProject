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
        private readonly IDataContext _dataContext;
        public BookController(IDataContext Context)
        {
            _dataContext = Context;
        }
        // GET: api/<LibaryController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _dataContext.books;
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            var index= _dataContext.books.FindIndex(x => x.Id==id);
            return _dataContext.books[index];
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
            _dataContext.books.Add(value);
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            var index = _dataContext.books.FindIndex(x => x.Id == id);
            _dataContext.books[index].Genre = value.Genre;
            _dataContext.books[index].IsAvailable = value.IsAvailable;
            
        }

            // DELETE api/<LibaryController>/5
            [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var index = _dataContext.books.Find(x => x.Id == id);
            _dataContext.books.Remove(index);
        }
    }
}
