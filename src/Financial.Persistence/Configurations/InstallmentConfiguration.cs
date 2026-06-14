using Financial.Domain.Entities.Installments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Persistence.Configurations;

public sealed class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
{
    public void Configure(EntityTypeBuilder<Installment> builder)
    {
        builder.ToTable("Installments");

        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.TotalAmount);
        builder.Ignore(x => x.RemainingAmount);

        builder.Property(x => x.PrincipalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.InterestAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.PenaltyAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.PaidAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.DueDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasIndex(x => new { x.LoanId, x.InstallmentNumber })
            .IsUnique();

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
