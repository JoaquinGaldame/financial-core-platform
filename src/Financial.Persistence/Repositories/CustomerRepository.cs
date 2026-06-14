using Financial.Application.Common.Interfaces;
using Financial.Domain.Entities.Customers;
using Financial.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Financial.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly FinancialDbContext _context;

    public CustomerRepository(FinancialDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetByIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .Include(x => x.DocumentType)
            .Include(x => x.CustomerType)
            .FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
    }

    public async Task<Customer?> GetByDocumentAsync(string documentNumber, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .Include(x => x.DocumentType)
            .Include(x => x.CustomerType)
            .FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Customer>> SearchAsync(
        string? firstName,
        string? lastName,
        string? documentNumber,
        string? email,
        int page,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var query = _context.Customers
            .Include(x => x.DocumentType)
            .Include(x => x.CustomerType)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(firstName))
            query = query.Where(x => x.FirstName.Contains(firstName));

        if (!string.IsNullOrWhiteSpace(lastName))
            query = query.Where(x => x.LastName.Contains(lastName));

        if (!string.IsNullOrWhiteSpace(documentNumber))
            query = query.Where(x => x.DocumentNumber.Contains(documentNumber));

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(x => x.Email.Contains(email));

        return await query
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _context.Customers.AddAsync(customer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
