using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IBorrowService
    {
        public List<Borrow> GetBorrow();
        public Borrow GetBorrowByBookId(int id);
        public Borrow DeleteBorrow(int bookId);
        public Borrow UpdateBorrow(int bookId,int customerId);
        public bool AddBorrow(Borrow b);
    }
}
