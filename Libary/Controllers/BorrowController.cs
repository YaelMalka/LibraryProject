using Library.Core.Services;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService  _borrowService;
        public BorrowController(IBorrowService Context)
        {
            _borrowService = Context;
        }

        // GET: api/<KategoryController>
        [HttpGet]
        public IEnumerable<Borrow> Get()
        {
            return _borrowService.GetBorrow();
        }

        // GET api/<KategoryController>/5
        [HttpGet("{idBook}")]//בדיקת ספר מסוים
        public Borrow Get(int idBook)
        {
            var index = _borrowService.GetBorrow().FindIndex(x => x.BookId == idBook);
            return _borrowService.GetBorrow()[index];
        }

        // POST api/<KategoryController>
        [HttpPost]
        public ActionResult Post([FromBody] Borrow value)
        {
            var borrow = _borrowService.GetBorrowByBookId(value.BookId);
            if (borrow != null)
            {
                return Conflict(); // BadRequest
            }
            _borrowService.GetBorrow().Add(value);
            return Ok(value);        
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
            var index = _borrowService.GetBorrow().Find(x => x.BookId == idBook);
            _borrowService.GetBorrow().Remove(index);
        }
    
    }
}
