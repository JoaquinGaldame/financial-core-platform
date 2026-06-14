using Financial.Domain.Common;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.Customers;
using Financial.Domain.Entities.Installments;
using Financial.Domain.Entities.LoanApplications;
using Financial.Domain.Entities.Payments;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Loans;

public class Loan : AuditableEntity
{
    public Guid CustomerId { get; private set; }

    public Customer? Customer { get; private set; }

    public Guid? LoanApplicationId { get; private set; }

    public LoanApplication? LoanApplication { get; private set; }

    public int CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public decimal PrincipalAmount { get; private set; }

    public decimal InterestRate { get; private set; }

    public decimal OutstandingBalance { get; private set; }

    public int TermMonths { get; private set; }

    public LoanStatus Status { get; private set; }

    public DateTime ApprovedAt { get; private set; }

    public DateTime? DisbursedAt { get; private set; }

    public DateTime? PaidAt { get; private set; }

    public ICollection<Installment> Installments { get; private set; } = new List<Installment>();

    public ICollection<Payment> Payments { get; private set; } = new List<Payment>();

    private Loan()
    {
    }

    public Loan(
        Guid customerId,
        int currencyId,
        decimal principalAmount,
        decimal interestRate,
        int termMonths,
        Guid? loanApplicationId = null)
    {
        if (customerId == Guid.Empty)
            throw new DomainException("Customer id is required.");

        if (currencyId <= 0)
            throw new DomainException("Currency is required.");

        if (principalAmount <= 0)
            throw new DomainException("Principal amount must be greater than zero.");

        if (termMonths <= 0)
            throw new DomainException("Term months must be greater than zero.");

        CustomerId = customerId;
        LoanApplicationId = loanApplicationId;
        CurrencyId = currencyId;
        PrincipalAmount = principalAmount;
        InterestRate = interestRate;
        TermMonths = termMonths;
        OutstandingBalance = principalAmount;
        Status = LoanStatus.Approved;
        ApprovedAt = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;
    }

    public void Disburse()
    {
        if (Status != LoanStatus.Approved)
            throw new DomainException("Only approved loans can be disbursed.");

        Status = LoanStatus.Active;
        DisbursedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }

    public void RegisterPayment(decimal amount)
    {
        if (Status != LoanStatus.Active)
            throw new DomainException("Only active loans can receive payments.");

        if (amount <= 0)
            throw new DomainException("Payment amount must be greater than zero.");

        OutstandingBalance -= amount;

        if (OutstandingBalance <= 0)
        {
            OutstandingBalance = 0;
            Status = LoanStatus.Paid;
            PaidAt = DateTime.UtcNow;
        }

        MarkAsUpdated();
    }

    public void MarkAsDefaulted()
    {
        if (Status != LoanStatus.Active)
            throw new DomainException("Only active loans can be marked as defaulted.");

        Status = LoanStatus.Defaulted;
        MarkAsUpdated();
    }

    public void Cancel()
    {
        if (Status != LoanStatus.Approved)
            throw new DomainException("Only approved loans can be cancelled.");

        Status = LoanStatus.Cancelled;
        MarkAsUpdated();
    }
}
