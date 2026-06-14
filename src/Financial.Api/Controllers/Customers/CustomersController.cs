using Financial.Application.Customers.Commands.CreateCustomer;
using Financial.Application.Customers.Queries.GetCustomerById;
using Financial.Application.Customers.Queries.SearchCustomers;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Api.Controllers.Customers;
[ApiController]
[Route("api/customers")]
public sealed class CustomersController : ControllerBase
{
    private readonly CreateCustomerHandler _createCustomerHandler;
    private readonly GetCustomerByIdHandler _getCustomerByIdHandler;
    private readonly SearchCustomersHandler _searchCustomersHandler;

    public CustomersController(
        CreateCustomerHandler createCustomerHandler,
        GetCustomerByIdHandler getCustomerByIdHandler,
        SearchCustomersHandler searchCustomersHandler)
    {
        _createCustomerHandler = createCustomerHandler;
        _getCustomerByIdHandler = getCustomerByIdHandler;
        _searchCustomersHandler = searchCustomersHandler;
    }


   [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        await _createCustomerHandler.HandleAsync(command, cancellationToken);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var customer = await _getCustomerByIdHandler.HandleAsync(
            new GetCustomerByIdQuery
            {
                CustomerId = id
            },
            cancellationToken);

        return Ok(customer);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string? firstName,
        [FromQuery] string? lastName,
        [FromQuery] string? documentNumber,
        [FromQuery] string? email,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var customers = await _searchCustomersHandler.HandleAsync(
            new SearchCustomersQuery
            {
                FirstName = firstName,
                LastName = lastName,
                DocumentNumber = documentNumber,
                Email = email,
                Page = page,
                PageSize = pageSize
            },
            cancellationToken);

        return Ok(customers);
    }
}