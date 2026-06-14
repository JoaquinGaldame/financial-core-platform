using Financial.Domain.Entities.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Persistence.Configurations;

public sealed class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        builder.ToTable("Vouchers");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.PaymentId)
            .IsUnique();

        builder.Property(x => x.Number)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PointOfSale)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => new { x.PointOfSale, x.Number })
            .IsUnique();

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.FileUrl)
            .HasMaxLength(500);

        builder.Property(x => x.Metadata)
            .HasMaxLength(2000);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.VoucherType)
            .WithMany()
            .HasForeignKey(x => x.VoucherTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
