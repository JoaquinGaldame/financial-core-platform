namespace Financial.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public int DocumentTypeId { get; set; }

    public string DocumentNumber { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }

    public int CustomerTypeId { get; set; } = 1;

    public string? TaxIdentification { get; set; }
}
