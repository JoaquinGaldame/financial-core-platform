using Financial.Domain.Common;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.Customers;
using Financial.Domain.Entities.Loans;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.LoanApplications;

public class LoanApplication : AuditableEntity
{
    public Guid CustomerId { get; private set; }

    public Customer? Customer { get; private set; }

    public decimal RequestedAmount { get; private set; }

    public int CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public int RequestedTermMonths { get; private set; }

    public string Purpose { get; private set; } = string.Empty;

    public LoanApplicationStatus Status { get; private set; }

    public int? RiskScore { get; private set; }

    public string? RejectionReason { get; private set; }

    public decimal? ApprovedAmount { get; private set; }

    public int? ApprovedTermMonths { get; private set; }

    public DateTime RequestedAt { get; private set; }

    public DateTime? ReviewedAt { get; private set; }

    public DateTime? ApprovedAt { get; private set; }

    public DateTime? RejectedAt { get; private set; }

    public Loan? Loan { get; private set; }

    private LoanApplication()
    {
    }

    public LoanApplication(
        Guid customerId,
        decimal requestedAmount,
        int currencyId,
        int requestedTermMonths,
        string purpose)
    {
        if (customerId == Guid.Empty)
            throw new DomainException("Customer id is required.");

        if (requestedAmount <= 0)
            throw new DomainException("Requested amount must be greater than zero.");

        if (currencyId <= 0)
            throw new DomainException("Currency is required.");

        if (requestedTermMonths <= 0)
            throw new DomainException("Requested term months must be greater than zero.");

        if (string.IsNullOrWhiteSpace(purpose))
            throw new DomainException("Purpose is required.");

        CustomerId = customerId;
        RequestedAmount = requestedAmount;
        CurrencyId = currencyId;
        RequestedTermMonths = requestedTermMonths;
        Purpose = purpose;
        Status = LoanApplicationStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void Submit()
    {
        if (Status != LoanApplicationStatus.Pending)
            throw new DomainException("Only pending loan applications can be submitted.");

        RequestedAt = DateTime.UtcNow;
        Status = LoanApplicationStatus.UnderReview;
        MarkAsUpdated();
    }

    public void Approve(decimal approvedAmount, int approvedTermMonths, int? riskScore = null)
    {
        if (Status != LoanApplicationStatus.UnderReview)
            throw new DomainException("Only loan applications under review can be approved.");

        if (approvedAmount <= 0)
            throw new DomainException("Approved amount must be greater than zero.");

        if (approvedAmount > RequestedAmount)
            throw new DomainException("Approved amount cannot be greater than requested amount.");

        if (approvedTermMonths <= 0)
            throw new DomainException("Approved term months must be greater than zero.");

        ApprovedAmount = approvedAmount;
        ApprovedTermMonths = approvedTermMonths;
        RiskScore = riskScore;
        ReviewedAt = DateTime.UtcNow;
        ApprovedAt = DateTime.UtcNow;
        RejectionReason = null;
        RejectedAt = null;
        Status = LoanApplicationStatus.Approved;
        MarkAsUpdated();
    }

    public void Reject(string reason, int? riskScore = null)
    {
        if (Status != LoanApplicationStatus.UnderReview)
            throw new DomainException("Only loan applications under review can be rejected.");

        if (string.IsNullOrWhiteSpace(reason))
            throw new DomainException("Rejection reason is required.");

        RejectionReason = reason;
        RiskScore = riskScore;
        ReviewedAt = DateTime.UtcNow;
        RejectedAt = DateTime.UtcNow;
        ApprovedAmount = null;
        ApprovedTermMonths = null;
        ApprovedAt = null;
        Status = LoanApplicationStatus.Rejected;
        MarkAsUpdated();
    }

    public void Cancel()
    {
        if (Status is LoanApplicationStatus.Approved or LoanApplicationStatus.Rejected or LoanApplicationStatus.Cancelled)
            throw new DomainException("The loan application cannot be cancelled in its current status.");

        Status = LoanApplicationStatus.Cancelled;
        MarkAsUpdated();
    }
}
