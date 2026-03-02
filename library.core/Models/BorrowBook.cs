using Libary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class BorrowBook
    {
        [Key]
        public int Number { get; set; }
        public Borrow Borrow { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
