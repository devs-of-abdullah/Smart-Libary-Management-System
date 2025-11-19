using Entity;

namespace Business.Interfaces
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<IEnumerable<Loan>> GetOverdueLoansAsync();
        Task LoanBookAsync(Loan loan);
        Task ReturnBookAsync(int loanId);
    }
}
