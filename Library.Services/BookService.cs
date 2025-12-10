using Libary;
using Library.Core.Repositories;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }

        public bool AddBook(Book b)
        {
            return _BookRepository.AddBook(b);
        }

        public Book DeleteBook(int bookId)
        {
            return _BookRepository.DeleteBook(bookId);
        }

        public List<Book> GetBooks()
        {
           return _BookRepository.GetBooks();
        }

        public Book GetByAuthor(string author)
        {
           return _BookRepository.GetByAuthor(author);
        }

        public Book GetById(int id)
        {
            return _BookRepository.GetById(id);
        }

        public Book UpdateBook(int bookId, bool available)
        {
            return _BookRepository.UpdateBook(bookId, available);
        }
    }
}
