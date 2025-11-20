using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();

        public Book GetById(int id);
        public Book GetByAuthor(string author);
    }
}
