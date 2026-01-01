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

        public Customer GetByBirthday(DateTime birthday)
        {
            return _customerRepository.GetByBirthday(birthday);
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<Customer> GetCustomer()
        {
            return _customerRepository.GetCustomer();
        }

        public Customer DeleteCustomer(int id)
        {
           
            var c= _customerRepository.DeleteCustomer(id);
            _customerRepository.Save();
            return c;   

        }

        public Customer UpdateCustomer(int id, int numBook, string add)
        {
            var c = _customerRepository.UpdateCustomer(id, numBook, add);
            _customerRepository.Save();
            return c;
        }

        public bool AddCustomer(Customer c)
        {
            var customer = GetById(c.Id);
            if (customer== null)
            {
                _customerRepository.AddCustomer(c);
                _customerRepository.Save();
                return true;
            }
            return false;
            
        }
        
    }
}
