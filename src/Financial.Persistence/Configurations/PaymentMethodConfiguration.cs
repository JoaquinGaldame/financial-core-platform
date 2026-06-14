using Financial.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Persistence.Configurations;

public sealed class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("PaymentMethods");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Code).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasData(
            new PaymentMethod(1, "CASH", "Cash"),
            new PaymentMethod(2, "BANK_TRANSFER", "Bank Transfer"),
            new PaymentMethod(3, "DEBIT_CARD", "Debit Card"),
            new PaymentMethod(4, "CREDIT_CARD", "Credit Card"),
            new PaymentMethod(5, "WALLET", "Wallet"),
            new PaymentMethod(6, "EXTERNAL_PROVIDER", "External Provider"));
    }
}
