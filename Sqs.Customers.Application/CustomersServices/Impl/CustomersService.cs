using Amazon.SQS.Model;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using Sqs.Infrastructure.DTO;
using Sqs.Infrastructure.MessagingQueue.Abstractions;

namespace Sqs.Customers.Application.CustomersServices.Impl
{
    public sealed class CustomersService : ICustomersServices
    {
        private readonly IEventBus _bus;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMessagingQueueService _messageQueueService;
        public CustomersService(IEventBus bus, 
            ICustomerRepository customerRepository, 
            IMessagingQueueService messageQueueService)
        {
            _bus = bus;
            _customerRepository = customerRepository;
            _messageQueueService = messageQueueService;
        }

        public void DeleteCustomer(Guid customerId)
        {
            var command = new DeleteCustomerCommand(customerId);
            _bus.SendCommand(command);
        }

        public (bool Success, Guid CustomerId, string Name, string GitHubUserName) InsertCustomer(CreateCustomerDTO dto)
        {
            var command = new CreateCustomerCommand
                (
                dto.Name,
                dto.Email,
                dto.GitHubUsername
                );
            _bus.SendCommand(command);
            var response = command.Response;
            if(response.Success) 
            {
                _messageQueueService.SendMessageAsync<SendMessageRequest>(command).Wait();
            }
            return response;
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
