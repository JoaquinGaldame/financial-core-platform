
namespace Financial.Domain.Entities.Payments;

    public enum PaymentStatus
    {
        Pending,
        Confirmed,
        Rejected,
        Reversed,
        Failed
    }