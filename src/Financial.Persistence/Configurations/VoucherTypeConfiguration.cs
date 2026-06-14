using Financial.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Persistence.Configurations;

public sealed class VoucherTypeConfiguration : IEntityTypeConfiguration<VoucherType>
{
    public void Configure(EntityTypeBuilder<VoucherType> builder)
    {
        builder.ToTable("VoucherTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Code).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasData(
            new VoucherType(1, "RECEIPT", "Receipt"),
            new VoucherType(2, "INVOICE", "Invoice"),
            new VoucherType(3, "CREDIT_NOTE", "Credit Note"),
            new VoucherType(4, "DEBIT_NOTE", "Debit Note"));
    }
}
