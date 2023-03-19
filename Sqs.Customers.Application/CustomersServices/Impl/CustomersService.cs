using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using Sqs.Infrastructure.DTO;

namespace Sqs.Customers.Application.CustomersServices.Impl
{
    public sealed class CustomersService : ICustomersServices
    {
        private readonly IEventBus _bus;
        private readonly ICustomerRepository _customerRepository;

        public CustomersService(IEventBus bus, ICustomerRepository customerRepo)
        {
            _bus = bus;
            _customerRepository = customerRepo; 
        }

        public void DeleteCustomer(Guid customerId)
        {
            var command = new DeleteCustomerCommand(customerId);
            _bus.SendCommand(command);
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

        public (Guid CustomerId, string Name, string GitHubUserName) UpdateCustomer(UpdateCustomerDTO dto)
        {
            var command = new UpdateCustomerCommand
                (
                dto.Id,
                dto.Name,
                dto.Email,
                dto.GitHubUsername
                );
            _bus.SendCommand(command);
            return command.Response;
        }
        public Customer GetById(Guid id) 
        {
            var customer = _customerRepository.GetById(id);
            if (customer is null)
                return null; 
            return customer;
        }
    }
}
