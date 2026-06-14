using Financial.Domain.Common;
using Financial.Domain.Entities.Accounts;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.Customers;
using Financial.Domain.Entities.Loans;
using Financial.Domain.Entities.Vouchers;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Payments;

public class Payment : AuditableEntity
{
    public Guid LoanId { get; private set; }

    public Loan? Loan { get; private set; }

    public Guid? AccountId { get; private set; }

    public Account? Account { get; private set; }

    public Guid CustomerId { get; private set; }

    public Customer? Customer { get; private set; }

    public decimal Amount { get; private set; }

    public int CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public int PaymentMethodId { get; private set; }

    public PaymentMethod? PaymentMethod { get; private set; }

    public PaymentStatus Status { get; private set; }

    public DateTime? ConfirmedAt { get; private set; }

    public DateTime? FailedAt { get; private set; }

    public DateTime? ReversedAt { get; private set; }

    public Voucher? Voucher { get; private set; }

    private Payment()
    {
    }

    public Payment(
        Guid customerId,
        Guid loanId,
        int currencyId,
        int paymentMethodId,
        decimal amount,
        Guid? accountId = null)
    {
        if (customerId == Guid.Empty)
            throw new DomainException("Customer id is required.");

        if (loanId == Guid.Empty)
            throw new DomainException("Loan id is required.");

        if (currencyId <= 0)
            throw new DomainException("Currency is required.");

        if (paymentMethodId <= 0)
            throw new DomainException("Payment method is required.");

        if (amount <= 0)
            throw new DomainException("Amount must be greater than zero.");

        CustomerId = customerId;
        LoanId = loanId;
        AccountId = accountId;
        CurrencyId = currencyId;
        PaymentMethodId = paymentMethodId;
        Amount = amount;
        Status = PaymentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void Confirm()
    {
        Status = PaymentStatus.Confirmed;
        ConfirmedAt = DateTime.UtcNow;
        FailedAt = null;
        ReversedAt = null;
        MarkAsUpdated();
    }

    public void Fail()
    {
        Status = PaymentStatus.Failed;
        FailedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }

    public void Reverse()
    {
        if (Status != PaymentStatus.Confirmed)
            throw new DomainException("Only confirmed payments can be reversed.");

        Status = PaymentStatus.Reversed;
        ReversedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }
}
