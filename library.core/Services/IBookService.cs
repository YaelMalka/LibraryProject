using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IBookService
    {
        public List<Book> GetBooks();

        public Book GetById(int id);
        public Book GetByAuthor(string author);
        public Book DeleteBook(int bookId);
        public Book UpdateBook(int bookId, bool available);
        public bool AddBook(Book b);
    }
}
