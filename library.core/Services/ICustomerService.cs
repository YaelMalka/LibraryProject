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
        public List<Customer> GetCustomer();
        public Customer GetById(int id);
        public Customer GetByBirthday(DateTime birthday);
        public Customer DeleteCustomer(int id);
        public Customer UpdateCustomer(int id, int numBook, string add);
        public bool AddCustomer(Customer c);
    }
}
