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

        public async Task<Borrow> UpdateBorrowAsync(int bookId, int customerId)
        {
            var s = await _borrowRepository.UpdateBorrowAsync(bookId, customerId);
            await _borrowRepository.SaveAsync();
            return s;
        }

        public async Task<bool> AddBorrowAsync(Borrow b)
        {
            var borrow = await GetBorrowByBookIdAsync(b.BookId);
            if (borrow == null)
            {
                await _borrowRepository.AddBorrowAsync(b);
                await _borrowRepository.SaveAsync();
                return true;
            }
            return false;

        }
    }
}
