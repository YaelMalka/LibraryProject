using Libary;
using Library.Core.Repositories;
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

        public bool AddBook(Book b)
        {
            if(GetById(b.Id)==null)
            {
                _context.books.Add(b);  
                return true;
            }
            return false;
        }

        public Book DeleteBook(int bookId)
        {
            var b = GetById(bookId);
            _context.books.Remove(b);
            return b;
        }

        public List<Book> GetBooks()
        {
           return _context.books;
        }

        public Book GetByAuthor(string author)
        {
            return _context.books.Find(s => s.Author == author);
        }

        public Book GetById(int id)
        {
            return _context.books.Find(s => s.Id == id);
        }

        public Book UpdateBook(int bookId, bool available)
        {
            Book b = GetById(bookId);
            b.IsAvailable = available;
            return b;             
        }
    }
}
