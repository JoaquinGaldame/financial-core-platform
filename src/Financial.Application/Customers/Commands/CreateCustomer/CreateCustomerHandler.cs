using Financial.Application.Common.Interfaces;
using Financial.Application.Customers.Commands.CreateCustomer;
using Financial.Domain.Entities.Customers;

public class CreateCustomerHandler
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task HandleAsync( CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer(
            command.FirstName,
            command.LastName,
            command.DocumentType,
            command.DocumentNumber,
            command.Email,
            command.PhoneNumber,
            command.BirthDate);

        await _customerRepository.AddAsync(
            customer,
            cancellationToken);
    }
}