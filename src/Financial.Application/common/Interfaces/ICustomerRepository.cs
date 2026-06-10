using Financial.Domain.Entities.Customers;

namespace Financial.Application.Common.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);

    Task<Customer?> GetByDocumentAsync(string documentNumber, CancellationToken cancellationToken);

    Task AddAsync(Customer customer, CancellationToken cancellationToken);

    Task UpdateAsync(Customer customer, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Customer>> SearchAsync(string? firstName, string? lastName, string? documentNumber, string? email, int page, int pageSize, CancellationToken cancellationToken);
}