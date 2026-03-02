using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTO
{
    public class BorrowDTO
    {
        
        public int CustomerId { get; set; }
        public List<int> BookIds { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate => BorrowDate.AddDays(30);
    }
}
