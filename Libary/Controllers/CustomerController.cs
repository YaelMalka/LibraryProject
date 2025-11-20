using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        public CustomerController(IDataContext Context)
        {
            _dataContext = Context;
        }

        // GET: api/<LibaryController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _dataContext.customers;
        }

        // GET api/<LibaryController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = _dataContext.customers.Find(e => e.Id == id);
            if (customer == null) {
                return NotFound();
            }
            return Ok(customer) ;
        }

        // POST api/<LibaryController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer value)
        {
            var customer = _dataContext.customers.Find(x => x.Id == value.Id);
            if (customer != null)
            {
                return Conflict(); // BadRequest
            }
            _dataContext.customers.Add(value);         
            return Ok(value);

           
        }

        // PUT api/<LibaryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer value)
        {          
            var index = _dataContext.customers.FindIndex(e => e.Id == id);
            _dataContext.customers[index].Birthday = value.Birthday;
            _dataContext.customers[index].Name = value.Name;
            _dataContext.customers[index].NumBooks = value.NumBooks;
            _dataContext.customers[index].Address = value.Address;
           
        }

        // DELETE api/<LibaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var index = _dataContext.customers.Find(e => e.Id == id);
            _dataContext.customers.Remove(index);
        }
    }
}
