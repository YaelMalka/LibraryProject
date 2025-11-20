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
        public Borrow GetByBorrowDate(DateTime date);
        public Borrow GetBorrowByBookId(int id);
    }
}
