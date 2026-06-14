using Financial.Domain.Entities.Accounts;
using Financial.Domain.Entities.Catalogs;
using Financial.Domain.Entities.Customers;
using Financial.Domain.Entities.Installments;
using Financial.Domain.Entities.LoanApplications;
using Financial.Domain.Entities.Loans;
using Financial.Domain.Entities.Payments;
using Financial.Domain.Entities.Vouchers;
using Microsoft.EntityFrameworkCore;

namespace Financial.Persistence.Context;

public class FinancialDbContext : DbContext
{
    public FinancialDbContext(DbContextOptions<FinancialDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<LoanApplication> LoanApplications => Set<LoanApplication>();

    public DbSet<Loan> Loans => Set<Loan>();

    public DbSet<Installment> Installments => Set<Installment>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<Voucher> Vouchers => Set<Voucher>();

    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();

    public DbSet<CustomerType> CustomerTypes => Set<CustomerType>();

    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

    public DbSet<VoucherType> VoucherTypes => Set<VoucherType>();

    public DbSet<Currency> Currencies => Set<Currency>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
