using Financial.Domain.Entities.Loans;

namespace Financial.Application.common.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan?> GetByIdAsync(Guid loanId, CancellationToken cancellationToken);

        Task AddAsync(Loan loan, CancellationToken cancellationToken);

        Task UpdateAsync(Loan loan, CancellationToken cancellationToken);
        
    }
}