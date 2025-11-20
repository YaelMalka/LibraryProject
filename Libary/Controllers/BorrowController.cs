using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        public BorrowController(IDataContext Context)
        {
            _dataContext = Context;
        }

        // GET: api/<KategoryController>
        [HttpGet]
        public IEnumerable<Borrow> Get()
        {
            return _dataContext.borrows;
        }

        // GET api/<KategoryController>/5
        [HttpGet("{idBook}")]//בדיקת ספר מסוים
        public Borrow Get(int idBook)
        {
            var index = _dataContext.borrows.FindIndex(x => x.BookId == idBook);
            return _dataContext.borrows[index];
        }

        // POST api/<KategoryController>
        [HttpPost]
        public void Post([FromBody] Borrow value)
        {
            _dataContext.borrows.Add(value);
        }

        // PUT api/<KategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int idBook, [FromBody] Borrow value)
        //{
        //   //לא ניתן לבצע עדכון על השאלה שהתרחשה כבר
        //}

        // DELETE api/<KategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int idBook)
        {
            var index = _dataContext.borrows.Find(x => x.BookId == idBook);
            _dataContext.borrows.Remove(index);
        }
    
    }
}
