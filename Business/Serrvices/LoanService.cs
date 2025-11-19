using Business.Interfaces;
using Data.Interfaces;
using Entity;

namespace Business.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepo;
        private readonly IBookRepository _bookRepo;

        public LoanService(ILoanRepository loanRepo, IBookRepository bookRepo)
        {
            _loanRepo = loanRepo;
            _bookRepo = bookRepo;
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _loanRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Loan>> GetOverdueLoansAsync()
        {
            return await _loanRepo.GetOverdueLoansAsync();
        }

        public async Task LoanBookAsync(Loan loan)
        {
            await _loanRepo.AddAsync(loan);

            var book = await _bookRepo.GetByIdAsync(loan.BookId);
            if (book != null) book.CopiesAvailable--;

            await _bookRepo.UpdateAsync(book);
        }

        public async Task ReturnBookAsync(int loanId)
        {
            var loan = await _loanRepo.GetByIdAsync(loanId);
            if (loan == null) return;

            loan.ReturnDate = DateTime.UtcNow;
            await _loanRepo.UpdateAsync(loan);

            var book = await _bookRepo.GetByIdAsync(loan.BookId);
            if (book != null)
            {
                book.CopiesAvailable++;
                await _bookRepo.UpdateAsync(book);
            }
        }
    }
}
