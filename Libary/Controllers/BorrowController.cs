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
        public async Task<ActionResult<Borrow>>Get()
        {
            return await Ok( _borrowService.GetBorrowAsync());
        }

        // GET api/<KategoryController>/5
        [HttpGet("{idBook}")]//בדיקת ספר מסוים
        public async Task<ActionResult> Get(int idBook)
        {
            var book = await _borrowService.GetBorrowByBookIdAsync(idBook);
            if(book==null)
                return NotFound();

            return Ok(book);
        }

        // POST api/<KategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Borrow value)
        {
            bool ans = await _borrowService.AddBorrowAsync(value);
            if (!ans)
            {
                return Conflict(); // BadRequest
            }
            return Ok(value);        
        }

        // PUT api/<KategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int idBook, [FromBody] Borrow value)
        //{
        //   //לא ניתן לבצע עדכון על השאלה שהתרחשה כבר
        //}

        // DELETE api/<KategoryController>/5
        [HttpDelete("{idbook}")]
        public async Task<ActionResult> Delete(int idbook)
        {
            var b = await _borrowService.DeleteBorrowAsync(idbook);
            if (b == null)
            {
                return NotFound();
            }
            return Ok(b);         
        }
    
    }
}
