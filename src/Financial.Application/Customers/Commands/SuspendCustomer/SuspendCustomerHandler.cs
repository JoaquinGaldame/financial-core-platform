using Financial.Application.Common.Interfaces;
using Financial.Application.Customers.Commands.SuspendCustomer;

public class SuspendCustomerHandler
{
    private readonly ICustomerRepository _customerRepository;

    public SuspendCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task HandleAsync(SuspendCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(command.CustomerId, cancellationToken);

        if (customer is null)
            throw new ApplicationException("Customer not found.");

        customer.Suspend();

        await _customerRepository.UpdateAsync(customer, cancellationToken);
    }
}