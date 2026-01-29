using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookRepository
    {
        public  Task<List<Book>> GetBooksAsync();
        public  Task<Book> GetByIdAsync(int id);
        public  Task<Book> GetByAuthorAsync(string author);
        public  Task<Book> DeleteBookAsync(int bookId);
        public  Task<Book> UpdateBookAsync(int bookId, bool available);
        public  Task<bool> AddBookAsync(Book b);
        public  Task SaveAsync();
    }
}
