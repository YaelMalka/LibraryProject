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
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBookAsync(Book b)
        {
            if(await GetByIdAsync(b.Id)==null)
            {
                _context.books.Add(b);  
                return true;
            }
            return false;
        }

        public async Task<Book>DeleteBookAsync(int bookId)
        {
            var b =await GetByIdAsync(bookId);
            _context.books.Remove(b);
            return b;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.books.ToListAsync();
        }

        public async Task<Book> GetByAuthorAsync(string author)
        {
            return await _context.books.FirstOrDefaultAsync(s => s.Author == author);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.books.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Book> UpdateBookAsync(int bookId, bool available)
        {
            Book b =await GetByIdAsync(bookId);
            b.IsAvailable = available;
            return b;             
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
