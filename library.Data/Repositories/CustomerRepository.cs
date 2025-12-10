using Libary;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddCustomer(Customer c)
        {
            if (GetById(c.Id) == null)
            {
                _context.customers.Add(c);
                return true;
            }
            return false;
        }

        public Customer DeleteCustomer(int id)
        {
            var cust = GetById(id);
            if (cust != null)
                _context.customers.Remove(cust);
            return cust;

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

        public Customer UpdateCustomer(int id, int numBook, string add)
        {
            Customer c = GetById(id);
            c.NumBooks = numBook;
            c.Address = add;
            return c;
        }
    }
}
