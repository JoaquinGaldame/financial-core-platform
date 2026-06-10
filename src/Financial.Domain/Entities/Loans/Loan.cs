using Financial.Domain.Entities.Loans;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Loans;

// Representa el crédito ya aprobado/desembolsado.
// It represents the credit that has already been approved/disbursed.
    public class Loan
    {
        public long Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public decimal PrincipalAmount { get; private set; }

        public decimal InterestRate { get; private set; }

        public decimal OutstandingBalance { get; private set; }

        public int TermMonths { get; private set; }

        public LoanStatus Status { get; private set; }

        public DateTime ApprovedAt { get; private set; }

        public DateTime? DisbursedAt { get; private set; }

        public DateTime? PaidAt { get; private set; }

        private Loan()
        {
            // Constructor requerido por EF Core
        }

        public Loan(
            Guid customerId,
            decimal principalAmount,
            decimal interestRate,
            int termMonths)
        {
            Id = 0; // EF Core will generate the ID

            CustomerId = customerId;
            PrincipalAmount = principalAmount;
            InterestRate = interestRate;
            TermMonths = termMonths;

            OutstandingBalance = principalAmount;

            Status = LoanStatus.Approved;

            ApprovedAt = DateTime.UtcNow;
        }

        public void Disburse()
        {
            if (Status != LoanStatus.Approved)
                throw new DomainException(
                    "Only approved loans can be disbursed.");

            Status = LoanStatus.Active;

            DisbursedAt = DateTime.UtcNow;
        }

        public void RegisterPayment(decimal amount)
        {
            if (Status != LoanStatus.Active)
                throw new DomainException(
                    "Only active loans can receive payments.");

            if (amount <= 0)
                throw new DomainException(
                    "Payment amount must be greater than zero.");

            OutstandingBalance -= amount;

            if (OutstandingBalance <= 0)
            {
                OutstandingBalance = 0;

                Status = LoanStatus.Paid;

                PaidAt = DateTime.UtcNow;
            }
        }

        public void MarkAsDefaulted()
        {
            if (Status != LoanStatus.Active)
                throw new DomainException(
                    "Only active loans can be marked as defaulted.");

            Status = LoanStatus.Defaulted;
        }

        public void Cancel()
        {
            if (Status != LoanStatus.Approved)
                throw new DomainException(
                    "Only approved loans can be cancelled.");

            Status = LoanStatus.Cancelled;
        }
    }
