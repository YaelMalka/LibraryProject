using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryControllerTest
{
    public class FakeContext:IDataContext
    {
        public List<Book> books { get; set; }
        public List<Borrow> borrows { get; set; }
        public List<Customer> customers { get; set; }

        public FakeContext()
        {
            books = new List<Book>() { new Book { Id = 1, Author = "fake", NameBook = "trip", Genre = "adult", IsAvailable = true } };
            borrows = new List<Borrow>() { new Borrow { CustomerId = 1, BookId = 90, BorrowDate = new DateTime(2025, 08, 17), }, new Borrow { CustomerId = 14, BookId = 98, BorrowDate = new DateTime(2024, 08, 11) } };
            customers = new List<Customer>() { new Customer { Id = 2, Name = "fake", Address = "fake", Birthday = new DateTime(), NumBooks = 5 } };
        }
    }
}
