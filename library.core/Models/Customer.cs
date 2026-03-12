using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libary
{
    public class Customer
    {
        [Key]                  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int NumBooks { get; set; }
        public List<Borrow> Borrows { get; set; }
    }
}
