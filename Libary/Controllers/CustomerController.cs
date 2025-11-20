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
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetCustomer();
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = _customerService.GetCustomer().Find(e => e.Id == id);
            if (customer == null) {
                return NotFound();
            }
            return Ok(customer) ;
        }

        // POST api/<LibaryController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer value)
        {
            var customer = _customerService.GetById(value.Id);  
            if (customer != null)
            {
                return Conflict(); // BadRequest
            }
            _customerService.GetCustomer().Add(value);         
            return Ok(value);

           
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer value)
        {          
            //לסיים עדכון
            var index = _customerService.GetCustomer().FindIndex(e => e.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            _customerService.GetCustomer()[index].Birthday = value.Birthday;
            _customerService.GetCustomer()[index].Name = value.Name;
            _customerService.GetCustomer()[index].NumBooks = value.NumBooks;
            _customerService.GetCustomer()[index].Address = value.Address;
           
        }

        // DELETE api/<LibaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var index = _customerService.GetCustomer().Find(e => e.Id == id);
            _customerService.GetCustomer().Remove(index);
        }
    }
}
