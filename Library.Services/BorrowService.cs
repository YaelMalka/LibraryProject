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
            var b= _borrowRepository.DeleteBorrow(bookId);
            _borrowRepository.Save();
            return b;
        }

        public Borrow UpdateBorrow(int bookId, int customerId)
        {
            var s = _borrowRepository.UpdateBorrow(bookId, customerId);
            _borrowRepository.Save();
            return s;
        }

        public bool AddBorrow(Borrow b)
        {
            var borrow = GetBorrowByBookId(b.BookId);
            if (borrow == null)
            {
                _borrowRepository.AddBorrow(b);
                _borrowRepository.Save();
                return true;
            }
            return false;

        }
    }
}
