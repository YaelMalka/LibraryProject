using Library.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Libary
{
    public class Borrow
    {
        [Key]
        public int BorrowId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate => BorrowDate.AddDays(30);
        public List<BorrowBook> BorrowBooks { get; set; }

    }
}
