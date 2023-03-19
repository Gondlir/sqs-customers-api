
using Sqs.Infrastructure.DTO;

namespace Sqs.Customers.Application.CustomersServices
{
    public interface ICustomersServices
    {
        (Guid CustomerId, string Name, string GitHubUserName) InsertCustomer(CreateCustomerDTO dto);
        void DeleteCustomer(Guid customerId);
        void UpdateCustomer(Guid customerId);
    }
}
