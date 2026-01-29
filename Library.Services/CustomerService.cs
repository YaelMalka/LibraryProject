using Libary;
using Library.Core.Repositories;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetByBirthdayAsync(DateTime birthday)
        {
            return await _customerRepository.GetByBirthdayAsync(birthday);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public  async Task<List<Customer>> GetCustomerAsync()
        {
            return await _customerRepository.GetCustomerAsync();
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
           
            var c= await _customerRepository.DeleteCustomerAsync(id);
            await _customerRepository.SaveAsync();
            return c;   

        }

        public async Task<Customer> UpdateCustomerAsync(int id, int numBook, string add)
        {
            var c = await _customerRepository.UpdateCustomerAsync(id, numBook, add);
           await _customerRepository.SaveAsync();
            return c;
        }

        public async Task<bool> AddCustomerAsync(Customer c)
        {
            var customer = await GetByIdAsync(c.Id);
            if (customer== null)
            {
                await _customerRepository.AddCustomerAsync(c);
                await _customerRepository.SaveAsync();
                return true;
            }
            return false;
            
        }
        
    }
}
