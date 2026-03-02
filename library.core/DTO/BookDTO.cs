using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
