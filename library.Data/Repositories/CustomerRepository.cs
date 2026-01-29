using Libary;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddCustomerAsync(Customer c)
        {
            if (await GetByIdAsync(c.Id) == null)
            {
                _context.customers.Add(c);
                return true;
            }
            return false;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var cust =await GetByIdAsync(id);
            if (cust != null)
                _context.customers.Remove(cust);
            return cust;

        }

        public async Task<Customer> GetByBirthdayAsync(DateTime birthday)
        {
            return await _context.customers.FirstOrDefaultAsync(x => x.Birthday == birthday);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Customer>>GetCustomerAsync()
        {
            return await _context.customers.Include(x => x.books).ToListAsync();  
        }

        public async Task<Customer> UpdateCustomerAsync(int id, int numBook, string add)
        {
            Customer c =await GetByIdAsync(id);
            c.NumBooks = numBook;
            c.Address = add;
            return c;
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
