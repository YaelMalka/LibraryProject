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
            return  await _context.borrows.Include(x=>x.Customer).Include(b => b.BorrowBooks)
                    .ThenInclude(bb => bb.Book)
                .ToListAsync();
        }

        public async Task<Borrow> GetBorrowByBookIdAsync(int id)
        {
            return await _context.borrows
                 .Include(b => b.Customer)
                 .Include(b => b.BorrowBooks)
                     .ThenInclude(bb => bb.Book)
                 .FirstOrDefaultAsync(b => b.BorrowId ==id);
        }

        public async Task<Borrow>DeleteBorrowAsync(int bookId)
        {
            var borrow = await GetBorrowByBookIdAsync(bookId);
            if (borrow != null)
            {
                _context.borrows.Remove(borrow);
            }
            return borrow;
        }

        public async Task<bool> AddBorrowAsync(Borrow b)
        {
            _context.borrows.Add(b);
            return true;
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        
    }
}
