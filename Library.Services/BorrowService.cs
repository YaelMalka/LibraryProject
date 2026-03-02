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
        private readonly IBookRepository _bookRepository;
        public BorrowService(IBorrowRepository borrowRepository, IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
        }

        public async Task<List<Borrow>> GetBorrowAsync()
        {
            return await _borrowRepository.GetBorrowAsync();
        }

        public async Task<Borrow>GetBorrowByBookIdAsync(int id)
        {
            return await _borrowRepository.GetBorrowByBookIdAsync(id);
        }

        public async Task<Borrow> DeleteBorrowAsync(int bookId)
        {
            var b= await _borrowRepository.DeleteBorrowAsync(bookId);
            await _borrowRepository.SaveAsync();
            return b;
        }
        public async Task<bool> AddBorrowAsync(Borrow b)
        {
            List<int> list=b.BorrowBooks.Select(x=> x.BookId).ToList();
            foreach (int bookId in list) {
                var book =await _bookRepository.GetByIdAsync(bookId);
                if (book == null || !book.IsAvailable)
                    return false;
            }
            await _borrowRepository.AddBorrowAsync(b);
            await _borrowRepository.SaveAsync();
            return true;
        }
    }
}
