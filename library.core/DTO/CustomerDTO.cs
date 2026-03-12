using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
       public string Phone { get; set; }
        public int NumBooks { get; set; }
        //public List<int> BorrowIds { get; set; }
    }
}
