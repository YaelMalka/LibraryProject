namespace Libary
{
    public interface IDataContext
    {
        public List<Book> books { get; set; }
        public List<Borrow> borrows { get; set; }
        public List<Customer> customers { get; set; }
    }
}
