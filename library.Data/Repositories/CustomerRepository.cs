using Libary;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public Customer GetByBirthday(DateTime birthday)
        {
            return _context.customers.Find(x => x.Birthday == birthday);
        }

        public Customer GetById(int id)
        {
            return _context.customers.Find(x => x.Id == id);
        }

        public List<Customer> GetCustomer()
        {
            return _context.customers;
        }
    }
}
