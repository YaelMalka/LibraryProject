using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomer();
        public Customer GetById(int id);
        public Customer GetByBirthday(DateTime birthday);
        public Customer DeleteCustomer(int id);
    }
}
