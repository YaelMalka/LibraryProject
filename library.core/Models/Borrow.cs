using System.ComponentModel.DataAnnotations;

namespace Libary
{
    public class Borrow
    {
       [Key]
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public Customer customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate => BorrowDate.AddDays(30);
        
    }
}
