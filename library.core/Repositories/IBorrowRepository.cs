using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public  interface IBorrowRepository
    {
        public List<Borrow> GetBorrow();
        public Borrow GetByBorrowDate(DateTime date);
        public Borrow GetBorrowByBookId(int id);
    }
}
