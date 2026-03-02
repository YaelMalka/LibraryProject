using AutoMapper;
using Library.Core.DTO;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService Context, IMapper mapper)
        {
            _customerService = Context;
            _mapper = mapper;
        }

        // GET: api/<LibaryController>
        [HttpGet]
        public async Task<ActionResult<Customer>> Get()
        {
<<<<<<< HEAD
            var customerTask=await _customerService.GetCustomerAsync();
            return Ok(customerTask);
=======
            return Ok(await _customerService.GetCustomerAsync());
>>>>>>> 20997490782c4306a258767b2a610d712d931ca8
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) {
                return NotFound();
            }
            return Ok(customer) ;
        }

        // POST api/<LibaryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerDTO value)
        {
            // ממפה מ־DTO לאובייקט EF
            var customer = new Customer
            {
                Id = value.Id,
                Name = value.Name,
                Birthday = value.Birthday,
                Address = value.Address,
                Phone = value.Phone,
                NumBooks = value.NumBooks,
                Borrows = new List<Borrow>() // אם רוצים להשאלות בעת יצירה אפשר למלא לפי BorrowIds
            };

            bool ans = await _customerService.AddCustomerAsync(customer);
            if (!ans)
            {
                return Conflict();
            }

            // מחזיר את ה־DTO נקי
            return Ok(value);
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CustomerDTO value)
        {     
            var cust = await _customerService.UpdateCustomerAsync(id, value.NumBooks, value.Address,value.Phone);
            if (cust ==null)
            {
                return NotFound();
            }          
           return Ok(cust);
        }

        // DELETE api/<LibaryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {         
           var cust= await _customerService.DeleteCustomerAsync(id);
            if (cust == null)
            {
                return NotFound();
            }          
            return Ok(cust);
        }
    }
}
