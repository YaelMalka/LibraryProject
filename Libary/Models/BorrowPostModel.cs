namespace Libary.Models
{
    public class BorrowPostModel
    {
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
