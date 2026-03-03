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
           

            return await _customerRepository.DeleteCustomerAsync(id);
           

            var c= await _customerRepository.DeleteCustomerAsync(id);
            await _customerRepository.SaveAsync();
            return c;   

        }

        public async Task<Customer> UpdateCustomerAsync(int id, int numBook, string add,int phone)
        {
            return await _customerRepository.UpdateCustomerAsync(id, numBook, add,phone);
        }

        public async Task<bool> AddCustomerAsync(Customer c)
        {
            bool result = await _customerRepository.AddCustomerAsync(c);
            return result;
        }
        
    }
}
