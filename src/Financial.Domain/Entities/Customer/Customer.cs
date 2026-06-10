using Financial.Domain.Common;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Customer;

    // Representa al cliente/persona.
    // It represents the customer or individual.
    public class Customer : AuditableEntity
    {

        public long Code { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DocumentType DocumentType { get; set; }

        public string DocumentNumber { get; set; } = "";

        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public DateOnly BirthDate { get; set; }

        public CustomerType CustomerType { get; set; }

        public string? TaxIdentification { get; set; } = "";

        public CustomerStatus Status { get; set; }

        private Customer()
        {
        }

        public Customer(
            string firstName,
            string lastName,
            DocumentType documentType,
            string documentNumber,
            string email,
            string phoneNumber,
            DateOnly birthDate,
            string? taxIdentification = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Last name is required.");

            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new DomainException("Document number is required.");

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email is required.");

            FirstName = firstName;
            LastName = lastName;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            TaxIdentification = taxIdentification;
            Status = CustomerStatus.Active;
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