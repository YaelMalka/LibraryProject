

namespace Libary
{
    public class DataContext:IDataContext
    {
        public List<Book> books { get; set; }
        public List<Borrow> borrows { get; set; }
        public List<Customer> customers { get; set; }

        public DataContext()
        {
          books=new List<Book>(){ new Book { Id = 123, Author = "Chavi bar", NameBook = "trip", Genre = "adult", IsAvailable = true }};
            borrows = new List<Borrow>() { new Borrow { CustomerId = 133, BookId = 145, BorrowDate = new DateTime(2025, 08, 17), }, new Borrow { CustomerId = 14, BookId = 98, BorrowDate = new DateTime(2024, 08, 11) } };
            customers=new List<Customer>() { new Customer { Id = 1, Name = "null", Address = "null", Birthday = new DateTime(), NumBooks = 5 } };
        }
    }
}
