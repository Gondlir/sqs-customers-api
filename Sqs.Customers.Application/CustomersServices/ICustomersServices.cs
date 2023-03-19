
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Infrastructure.DTO;

namespace Sqs.Customers.Application.CustomersServices
{
    public interface ICustomersServices
    {
        (bool Success, Guid CustomerId, string Name, string GitHubUserName) InsertCustomer(CreateCustomerDTO dto);
        (Guid CustomerId, string Name, string GitHubUserName) UpdateCustomer(UpdateCustomerDTO dto);
        void DeleteCustomer(Guid customerId);
        Customer GetById(Guid id);
    }
}
