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
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate => BorrowDate.AddDays(30);
    }
}
