using Financial.Domain.Common;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.Customers;
using Financial.Domain.Entities.Payments;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Accounts;

public class Account : AuditableEntity
{
    public Guid CustomerId { get; private set; }

    public Customer? Customer { get; private set; }

    public string AccountNumber { get; private set; } = string.Empty;

    public int CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public decimal Balance { get; private set; }

    public decimal AvailableBalance { get; private set; }

    public AccountStatus Status { get; private set; }

    public DateTime? ActivatedAt { get; private set; }

    public DateTime? BlockedAt { get; private set; }

    public DateTime? ClosedAt { get; private set; }

    public ICollection<Payment> Payments { get; private set; } = new List<Payment>();

    private Account()
    {
    }

    public Account(Guid customerId, string accountNumber, int currencyId)
    {
        if (customerId == Guid.Empty)
            throw new DomainException("Customer id is required.");

        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new DomainException("Account number is required.");

        if (currencyId <= 0)
            throw new DomainException("Currency is required.");

        CustomerId = customerId;
        AccountNumber = accountNumber;
        CurrencyId = currencyId;
        Status = AccountStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        Status = AccountStatus.Active;
        ActivatedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }

    public void Block()
    {
        Status = AccountStatus.Blocked;
        BlockedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }

    public void Close()
    {
        Status = AccountStatus.Closed;
        ClosedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }
}
