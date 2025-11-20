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

        public List<Book> GetBooks()
        {
            //חישובים
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
        public void Update(int id,Book b)
        {
            var value = _BookRepository.GetById(id);
            value.Genre=b.Genre;
            value.IsAvailable=b.IsAvailable;
        }
    }
}
