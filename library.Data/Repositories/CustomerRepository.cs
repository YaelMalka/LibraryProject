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
<<<<<<< HEAD
            _context.customers.Add(c);
            await _context.SaveChangesAsync();
            return true;
=======
            if (await GetByIdAsync(c.Id) == null)
            {
                _context.customers.Add(c);
                return true;
            }
            return false;
>>>>>>> 20997490782c4306a258767b2a610d712d931ca8
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var cust = await GetByIdAsync(id);
            if (cust != null)
            {
                _context.customers.Remove(cust);
                await _context.SaveChangesAsync();
            }
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

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _context.customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(int id, int numBook, string add,int phone)
        {
            Customer c = await GetByIdAsync(id);
            if (c == null) return null;
            c.NumBooks = numBook;
            c.Address = add;
            c.Phone = phone;
            await _context.SaveChangesAsync();
            return c;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
