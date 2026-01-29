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

        public async Task<List<Borrow>>GetBorrowAsync()
        {
            return  await _context.borrows.Include(x=>x.customer).ThenInclude(x=>x.books).ToListAsync();
        }

        public async Task<Borrow> GetBorrowByBookIdAsync(int id)
        {
            return await _context.borrows.FirstOrDefaultAsync(x => x.BookId == id);
        }

        public async Task<Borrow>DeleteBorrowAsync(int bookId)
        {
            var b =await GetBorrowByBookIdAsync(bookId);
            _context.borrows.Remove(b);
            return b;
        }

        public async Task<Borrow> UpdateBorrowAsync(int bookId, int customerId)
        {
            Borrow b =await GetBorrowByBookIdAsync(bookId);
            b.BookId = bookId;
            b.CustomerId = customerId;
            return b;
        }

        public async Task<bool> AddBorrowAsync(Borrow b)
        {
            if (await GetBorrowByBookIdAsync(b.BookId) == null)
            {
                _context.borrows.Add(b);
               return true;
            }
            return false;
        }
        public Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
