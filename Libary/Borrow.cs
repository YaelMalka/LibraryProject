namespace Libary
{
    public class Borrow
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate => BorrowDate.AddDays(30);
        
    }
}
