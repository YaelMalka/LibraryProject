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
        public ActionResult Get()
        {
            return Ok(_customerService.GetCustomer());
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null) {
                return NotFound();
            }
            return Ok(customer) ;
        }

        // POST api/<LibaryController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer value)
        {
            bool ans = _customerService.AddCustomer(value);  
            if (!ans)
            {
                return Conflict(); // BadRequest
            }     
            return Ok(value);         
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer value)
        {     
            var cust = _customerService.UpdateCustomer(id, value.NumBooks, value.Address);
            if (cust ==null)
            {
                return NotFound();
            }          
           return Ok(cust);
        }

        // DELETE api/<LibaryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {         
           var cust= _customerService.DeleteCustomer(id);
            if (cust == null)
            {
                return NotFound();
            }          
            return Ok(cust);
        }
    }
}
