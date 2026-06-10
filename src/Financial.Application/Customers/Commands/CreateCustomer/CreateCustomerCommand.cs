using Financial.Domain.ValueObjects.Documents;

namespace Financial.Application.Customers.Commands.CreateCustomer;
public class CreateCustomerCommand
{
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    
}