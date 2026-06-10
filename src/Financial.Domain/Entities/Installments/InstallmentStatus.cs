
namespace Financial.Domain.Entities.Installments;
    public enum InstallmentStatus
    {
        Pending,
        PartiallyPaid,
        Paid,
        Overdue,
        Cancelled
    }