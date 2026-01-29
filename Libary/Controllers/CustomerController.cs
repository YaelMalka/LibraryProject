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
        public CustomerController(ICustomerService Context)
        {
            _customerService = Context;
        }

        // GET: api/<LibaryController>
        [HttpGet]
        public async Task<ActionResult<Customer>> Get()
        {
            return await Ok(_customerService.GetCustomerAsync());
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
        public async Task<ActionResult> Post([FromBody] Customer value)
        {
            bool ans = await _customerService.AddCustomerAsync(value);  
            if (!ans)
            {
                return Conflict(); // BadRequest
            }     
            return Ok(value);         
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Customer value)
        {     
            var cust = await _customerService.UpdateCustomerAsync(id, value.NumBooks, value.Address);
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
