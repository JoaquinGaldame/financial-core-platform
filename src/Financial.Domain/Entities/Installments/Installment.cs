using Financial.Domain.Common;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.Loans;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Installments;

public class Installment : AuditableEntity
{
    public Guid LoanId { get; private set; }

    public Loan? Loan { get; private set; }

    public int CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public int InstallmentNumber { get; private set; }

    public DateOnly DueDate { get; private set; }

    public decimal PrincipalAmount { get; private set; }

    public decimal InterestAmount { get; private set; }

    public decimal PenaltyAmount { get; private set; }

    public decimal TotalAmount => PrincipalAmount + InterestAmount + PenaltyAmount;

    public decimal PaidAmount { get; private set; }

    public decimal RemainingAmount => TotalAmount - PaidAmount;

    public InstallmentStatus Status { get; private set; }

    public DateTime? PaidAt { get; private set; }

    private Installment()
    {
    }

    public Installment(
        Guid loanId,
        int currencyId,
        int installmentNumber,
        DateOnly dueDate,
        decimal principalAmount,
        decimal interestAmount)
    {
        if (loanId == Guid.Empty)
            throw new DomainException("Loan id is required.");

        if (currencyId <= 0)
            throw new DomainException("Currency is required.");

        if (installmentNumber <= 0)
            throw new DomainException("Installment number must be greater than zero.");

        LoanId = loanId;
        CurrencyId = currencyId;
        InstallmentNumber = installmentNumber;
        DueDate = dueDate;
        PrincipalAmount = principalAmount;
        InterestAmount = interestAmount;
        Status = InstallmentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void RegisterPayment(decimal amount)
    {
        if (amount <= 0)
            throw new DomainException("Payment amount must be greater than zero.");

        PaidAmount += amount;

        if (PaidAmount >= TotalAmount)
        {
            PaidAmount = TotalAmount;
            Status = InstallmentStatus.Paid;
            PaidAt = DateTime.UtcNow;
        }
        else
        {
            Status = InstallmentStatus.PartiallyPaid;
        }

        MarkAsUpdated();
    }
}
