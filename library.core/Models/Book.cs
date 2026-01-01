using static System.Reflection.Metadata.BlobBuilder;

namespace Libary
{
    public class Book
    {      

        public int Id { get; set; }
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }

    }
}
