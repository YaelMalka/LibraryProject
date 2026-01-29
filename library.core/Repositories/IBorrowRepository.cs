using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public  interface IBorrowRepository
    {
        public  Task<List<Borrow>> GetBorrowAsync();
        public  Task<Borrow> GetBorrowByBookIdAsync(int id);
        public  Task<Borrow> DeleteBorrowAsync(int bookId);
        public  Task<Borrow> UpdateBorrowAsync(int bookId, int customerId);
        public  Task<bool> AddBorrowAsync(Borrow b);
        public  Task SaveAsync();
    }
}
