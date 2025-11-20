using Libary;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly DataContext _context;

        public BorrowRepository(DataContext context)
        {
            _context = context;
        }

        public List<Borrow> GetBorrow()
        {
            return _context.borrows;
        }

        public Borrow GetByBorrowDate(DateTime date)
        {
            return _context.borrows.Find(x => x.BorrowDate == date);
        }

        public Borrow GetBorrowByBookId(int id)
        {
            return _context.borrows.Find(x => x.BookId == id);
        }
    }
}
