namespace Financial.Application.Customers.Queries.SearchCustomers;

public sealed class SearchCustomersQuery
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? DocumentNumber { get; set; }

    public string? Email { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}