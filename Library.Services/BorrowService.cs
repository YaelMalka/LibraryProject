using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libary;
using Library.Core.Services;
using System.Threading.Tasks;
using Library.Core.Repositories;

namespace Library.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;

        public BorrowService(IBorrowRepository borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public List<Borrow> GetBorrow()
        {
           return _borrowRepository.GetBorrow();
        }

        public Borrow GetBorrowByBookId(int id)
        {
            return _borrowRepository.GetBorrowByBookId(id);
        }

        public Borrow DeleteBorrow(int bookId)
        {
            return _borrowRepository.DeleteBorrow(bookId);
        }

        public Borrow UpdateBorrow(int bookId, int customerId)
        {
           return _borrowRepository.UpdateBorrow(bookId, customerId);
        }

        public bool AddBorrow(Borrow b)
        {
            var borrow =GetBorrowByBookId(b.BookId);
            if (borrow == null)
            {
                _borrowRepository.AddBorrow(b);
                return true;
            }
            return false;
           
             
        }
    }
}
