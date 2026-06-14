using Financial.Domain.Common;
using Financial.Domain.Entities.Accounts;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.LoanApplications;
using Financial.Domain.Entities.Loans;
using Financial.Domain.Entities.Payments;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Customers;

public class Customer : AuditableEntity
{
    public long Code { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public int DocumentTypeId { get; private set; }

    public DocumentType? DocumentType { get; private set; }

    public string DocumentNumber { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string PhoneNumber { get; private set; } = string.Empty;

    public DateOnly BirthDate { get; private set; }

    public int CustomerTypeId { get; private set; }

    public CustomerType? CustomerType { get; private set; }

    public string? TaxIdentification { get; private set; }

    public CustomerStatus Status { get; private set; }

    public ICollection<Account> Accounts { get; private set; } = new List<Account>();

    public ICollection<LoanApplication> LoanApplications { get; private set; } = new List<LoanApplication>();

    public ICollection<Loan> Loans { get; private set; } = new List<Loan>();

    public ICollection<Payment> Payments { get; private set; } = new List<Payment>();

    private Customer()
    {
    }

    public Customer(
        string firstName,
        string lastName,
        int documentTypeId,
        string documentNumber,
        string email,
        string phoneNumber,
        DateOnly birthDate,
        int customerTypeId,
        string? taxIdentification = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name is required.");

        if (documentTypeId <= 0)
            throw new DomainException("Document type is required.");

        if (string.IsNullOrWhiteSpace(documentNumber))
            throw new DomainException("Document number is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        if (customerTypeId <= 0)
            throw new DomainException("Customer type is required.");

        FirstName = firstName;
        LastName = lastName;
        DocumentTypeId = documentTypeId;
        DocumentNumber = documentNumber;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        CustomerTypeId = customerTypeId;
        TaxIdentification = taxIdentification;
        Status = CustomerStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateContactInfo(string email, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        Email = email;
        PhoneNumber = phoneNumber;
        MarkAsUpdated();
    }

    public void Suspend()
    {
        if (Status == CustomerStatus.Suspended)
            throw new DomainException("Customer is already suspended.");

        Status = CustomerStatus.Suspended;
        MarkAsUpdated();
    }

    public void Activate()
    {
        if (Status == CustomerStatus.Active)
            throw new DomainException("Customer is already active.");

        Status = CustomerStatus.Active;
        MarkAsUpdated();
    }

    public void Inactivate()
    {
        if (Status == CustomerStatus.Inactive)
            throw new DomainException("Customer is already inactive.");

        Status = CustomerStatus.Inactive;
        MarkAsUpdated();
    }
}
