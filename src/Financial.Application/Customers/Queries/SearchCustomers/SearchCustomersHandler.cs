using Financial.Application.Common.Interfaces;
using Financial.Domain.Entities.Customers;

namespace Financial.Application.Customers.Queries.SearchCustomers;

public sealed class SearchCustomersHandler
{
    private readonly ICustomerRepository _customerRepository;

    public SearchCustomersHandler(
        ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IReadOnlyCollection<Customer>> HandleAsync(SearchCustomersQuery query, CancellationToken cancellationToken)
    {
        return await _customerRepository.SearchAsync(
            query.FirstName,
            query.LastName,
            query.DocumentNumber,
            query.Email,
            query.Page,
            query.PageSize,
            cancellationToken);
    }
}