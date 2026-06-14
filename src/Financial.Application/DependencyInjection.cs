using Financial.Application.Customers.Commands.ActivateCustomer;
using Financial.Application.Customers.Commands.CreateCustomer;
using Financial.Application.Customers.Commands.SuspendCustomer;
using Financial.Application.Customers.Queries.GetCustomerById;
using Financial.Application.Customers.Queries.SearchCustomers;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateCustomerHandler>();
        services.AddScoped<ActivateCustomerHandler>();
        services.AddScoped<SuspendCustomerHandler>();
        services.AddScoped<GetCustomerByIdHandler>();
        services.AddScoped<SearchCustomersHandler>();

        return services;
    }
}
