using Financial.Domain.Common;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.Payments;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities.Vouchers;

public class Voucher : AuditableEntity
{
    public Guid PaymentId { get; private set; }

    public Payment? Payment { get; private set; }

    public int VoucherTypeId { get; private set; }

    public VoucherType? VoucherType { get; private set; }

    public string Number { get; private set; } = string.Empty;

    public string PointOfSale { get; private set; } = string.Empty;

    public VoucherStatus Status { get; private set; } = VoucherStatus.Draft;

    public DateTime IssuedAt { get; private set; }

    public string? FileUrl { get; private set; }

    public string? Metadata { get; private set; }

    private Voucher()
    {
    }

    public Voucher(Guid paymentId, int voucherTypeId, string number, string pointOfSale)
    {
        if (paymentId == Guid.Empty)
            throw new DomainException("Payment id is required.");

        if (voucherTypeId <= 0)
            throw new DomainException("Voucher type is required.");

        if (string.IsNullOrWhiteSpace(number))
            throw new DomainException("Voucher number is required.");

        PaymentId = paymentId;
        VoucherTypeId = voucherTypeId;
        Number = number;
        PointOfSale = pointOfSale;
        IssuedAt = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;
    }

    public void Issue(string? fileUrl = null, string? metadata = null)
    {
        Status = VoucherStatus.Issued;
        FileUrl = fileUrl;
        Metadata = metadata;
        IssuedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }

    public void Cancel()
    {
        Status = VoucherStatus.Cancelled;
        MarkAsUpdated();
    }
}
