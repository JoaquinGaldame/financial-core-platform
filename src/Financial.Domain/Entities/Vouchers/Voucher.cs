
namespace Financial.Domain.Entities.Vouchers;

    // Representa el comprobante del pago.
    // It represents proof of payment.
    public class Voucher
    {
        public long Id { get; set; }
        public Guid PaymentId { get; set; }
        public string Number { get; set; } = string.Empty;
        public string PointOfSale { get; set; } = string.Empty;
        public VoucherTypes Type { get; set; }
        public VoucherStatus Status { get; set; } = VoucherStatus.Draft;
        public DateTime IssuedAt { get; set; }
        public string? FileUrl { get; set; }
        public string? Metadata { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
