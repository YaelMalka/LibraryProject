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

        public bool AddBook(Book b,Customer c)
        {
            var x= _BookRepository.AddBook(b);
            _BookRepository.Save();
            return x;
        }

        public Book DeleteBook(int bookId)
        {
            var b= _BookRepository.DeleteBook(bookId);         
            _BookRepository.Save();
            return b;
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
            var b= _BookRepository.UpdateBook(bookId, available);
            _BookRepository.Save();
            return b;
        }
        //פונקציה לבדיקת הגבלת ספרים
        //public bool CheckTime(Customer c)
        //{
        //    var cust = GetById(c.Id);
        //    if (cust != null)
        //    {
        //        if (cust.NumBooks < cust.books.Count())
        //            return true;
        //    }
        //    return false;
        //}

    }
}
