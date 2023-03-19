using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using Sqs.Infrastructure.DTO;

namespace Sqs.Customers.Application.CustomersServices.Impl
{
    public sealed class CustomersService : ICustomersServices
    {
        private readonly IEventBus _bus;

        public CustomersService(IEventBus bus)
        {
            _bus = bus;
        }

        public void DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public (Guid CustomerId, string Name, string GitHubUserName) InsertCustomer(CreateCustomerDTO dto)
        {
            var command = new CreateCustomerCommand
                (
                dto.Name,
                dto.Email,
                dto.GitHubUsername
                );
            _bus.SendCommand(command);
            return command.Response;
        }

        public void UpdateCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
