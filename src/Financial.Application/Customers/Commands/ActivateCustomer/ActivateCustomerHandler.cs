using Financial.Application.Common.Interfaces;
using Financial.Application.Customers.Commands.ActivateCustomer;

public class ActivateCustomerHandler
{

    private readonly ICustomerRepository _customerRepository;

    public ActivateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task HandleAsync(ActivateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(command.CustomerId, cancellationToken);

        if (customer is null)
            throw new ApplicationException("Customer not found.");

        customer.Activate();

        await _customerRepository.UpdateAsync(customer, cancellationToken);
    }
}
