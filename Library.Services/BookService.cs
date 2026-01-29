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

        public async Task<bool> AddBookAsync(Book b)
        {
            var x=await _BookRepository.AddBookAsync(b);
            await _BookRepository.SaveAsync();
            return x;
        }

        public async Task<Book> DeleteBookAsync(int bookId)
        {
            var b=await _BookRepository.DeleteBookAsync(bookId);
            await _BookRepository.SaveAsync();
            return b;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
           return await _BookRepository.GetBooksAsync();
        }

        public async Task<Book> GetByAuthorAsync(string author)
        {
           return await _BookRepository.GetByAuthorAsync(author);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _BookRepository.GetByIdAsync(id);
        }

        public async Task<Book> UpdateBookAsync(int bookId, bool available)
        {
            var b= await _BookRepository.UpdateBookAsync(bookId, available);
            await _BookRepository.SaveAsync();
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
