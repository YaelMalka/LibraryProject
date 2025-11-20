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
    }
}
