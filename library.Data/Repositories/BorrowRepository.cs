using Libary;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
            return _context.borrows.Include(x=>x.customer).ThenInclude(x=>x.books).ToList();
        }

        public Borrow GetBorrowByBookId(int id)
        {
            return _context.borrows.ToList().Find(x => x.BookId == id);
        }

        public Borrow DeleteBorrow(int bookId)
        {
            var b = GetBorrowByBookId(bookId);
            _context.borrows.Remove(b);
            return b;
        }

        public Borrow UpdateBorrow(int bookId, int customerId)
        {
            Borrow b = GetBorrowByBookId(bookId);
            b.BookId = bookId;
            b.CustomerId = customerId;
            return b;
        }

        public bool AddBorrow(Borrow b)
        {
            if (GetBorrowByBookId(b.BookId) == null)
            {
                _context.borrows.Add(b);
               return true;
            }
            return false;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
