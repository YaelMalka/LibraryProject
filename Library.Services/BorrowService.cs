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

        public Borrow GetByBorrowDate(DateTime d)
        {
            return _borrowRepository.GetByBorrowDate(d);
        }

        public Borrow GetBorrowByBookId(int id)
        {
            return _borrowRepository.GetBorrowByBookId(id);
        }
    }
}
