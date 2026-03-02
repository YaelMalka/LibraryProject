using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface ICustomerService
    {
        public  Task<List<Customer>> GetCustomerAsync();
        public  Task<Customer> GetByIdAsync(int id);
        public  Task<Customer> DeleteCustomerAsync(int id);
        public  Task<Customer> UpdateCustomerAsync(int id, int numBook, string add,int tel);
        public  Task<bool> AddCustomerAsync(Customer c);
    }
}
