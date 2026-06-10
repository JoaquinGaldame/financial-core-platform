using Financial.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace Financial.Persistence.Context;

public class FinancialDbContext : DbContext
{
    public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(FinancialDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}