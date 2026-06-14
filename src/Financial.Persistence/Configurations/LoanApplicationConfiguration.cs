using Financial.Domain.Entities.LoanApplications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Persistence.Configurations;

public sealed class LoanApplicationConfiguration : IEntityTypeConfiguration<LoanApplication>
{
    public void Configure(EntityTypeBuilder<LoanApplication> builder)
    {
        builder.ToTable("LoanApplications");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RequestedAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.RequestedTermMonths)
            .IsRequired();

        builder.Property(x => x.Purpose)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.RejectionReason)
            .HasMaxLength(500);

        builder.Property(x => x.ApprovedAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.RequestedAt)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Loan)
            .WithOne(x => x.LoanApplication)
            .HasForeignKey<Financial.Domain.Entities.Loans.Loan>(x => x.LoanApplicationId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
