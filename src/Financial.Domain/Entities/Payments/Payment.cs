using Financial.Domain.Common;

namespace Financial.Domain.Entities.Payments;

    // Representa un pago realizado por el cliente.
    // It represents a payment made by the customer.
    public class Payment : AuditableEntity
    {

        public long LoanId { get; set; }

        public Guid AccountId { get; set; }

        public Guid CustomerId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = string.Empty;

        public PaymentMethod Method { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime? ConfirmedAt { get; set; }

        public DateTime? FailedAt { get; set; }

        public DateTime? ReversedAt { get; set; }

    }
