using Financial.Domain.Common;
using Financial.Domain.Entities.Payments;

namespace Financial.Domain.Entities.Accounts;

    // Representa una cuenta financiera asociada al cliente.
    // It represents a financial account associated with the client.
    public class Account : AuditableEntity
    {
        public Guid CustomerId { get; set; }

        public string? AccountNumber { get; set; }

        public string Currency { get; set; } = string.Empty;

        public decimal Balance { get; set; } = 0m;

        public decimal AvailableBalance { get; set; } = 0m;

        public AccountStatus Status { get; set; } = AccountStatus.Pending;

        public DateTime? ActivatedAt  { get; }

        public DateTime? BlockedAt { get; }

        public DateTime? ClosedAt { get; }

        public List<Payment> Payments { get; set; } = new List<Payment>(); 
    }
