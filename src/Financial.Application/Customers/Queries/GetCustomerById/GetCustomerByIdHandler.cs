using Financial.Application.Common.Interfaces;
using Financial.Domain.Entities.Customers;

namespace Financial.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdHandler
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdHandler(
        ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> HandleAsync(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(
            query.CustomerId,
            cancellationToken);

        if (customer is null)
            throw new ApplicationException($"Customer '{query.CustomerId}' was not found.");

        return customer;
    }
}