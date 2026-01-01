namespace Libary
{
    public class Customer
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumBooks { get; set; }
        public  List<Book> books { get; set; }

    }
}
