using AutoMapper;
using Library.Core.DTO;
using Library.Core.Models;
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
        private readonly IMapper _mapper;
        public BorrowController(IBorrowService Context, IMapper mapper)
        {
            _mapper = mapper;
            _borrowService = Context;
        }

        // GET: api/<KategoryController>
        [HttpGet]
        public async Task<ActionResult<List<BorrowDTO>>>Get()
        {
<<<<<<< HEAD
            var borrows = await _borrowService.GetBorrowAsync(); // כולל BorrowBooks + Book
            var borrowDtos = _mapper.Map<List<BorrowDTO>>(borrows);
            return Ok(borrowDtos);
=======
            return  Ok(await _borrowService.GetBorrowAsync());
>>>>>>> 20997490782c4306a258767b2a610d712d931ca8
        }

        // GET api/<KategoryController>/5
        [HttpGet("{idBook}")]//בדיקת ספר מסוים
        public async Task<ActionResult> Get(int idBook)
        {
            var borrow = await _borrowService.GetBorrowByBookIdAsync(idBook);
            if(borrow == null)
                return NotFound();
            return Ok(_mapper.Map<BorrowDTO>(borrow));
        }

        // POST api/<KategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateBorrowDTO dto)
        {
            var borrow = new Borrow
            {
                CustomerId = dto.CustomerId,
                BorrowDate = dto.BorrowDate,
                BorrowBooks = dto.BookIds
                   .Select(id => new BorrowBook { BookId = id })
                   .ToList()
            };

            bool success = await _borrowService.AddBorrowAsync(borrow);
            if (!success) return BadRequest(); // משהו השתבש

            return Ok(_mapper.Map<BorrowDTO>(borrow));
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
            var b = await _borrowService.GetBorrowByBookIdAsync(idbook);
            if (b == null)
            {
                return BadRequest();
            }
            await _borrowService.DeleteBorrowAsync(idbook);
            return Ok();         
        }
    
    }
}
