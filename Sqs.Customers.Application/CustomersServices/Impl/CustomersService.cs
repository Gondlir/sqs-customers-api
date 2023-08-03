
using Amazon.SimpleNotificationService.Model;
using Sqs.Customers.Application.MessagingServices;
using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using Sqs.Infrastructure.DTO;
using Sqs.Infrastructure.MessagingQueue.Abstractions;

namespace Sqs.Customers.Application.CustomersServices.Impl
{
    public sealed class CustomersService : ICustomersServices
    {
        private readonly IEventCommandBusSender _bus;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMessagingQueueService _messageQueueService;
        public CustomersService(IEventCommandBusSender bus, 
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
            if (command.Success)
            {
                _messageQueueService.PublishMessageAsync<PublishRequest>(DomainToMessageMapper.ToCustomerResponse(command)).Wait();
            }
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
            if (command.Response.Success) 
            {
                // refact logic
                _messageQueueService.PublishMessageAsync<PublishRequest>(DomainToMessageMapper.ToCustomerResponse(command)).Wait(); // => Wais is bad practice ;
            }
            return command.Response;
        }
        // implementar nos outros
        public (bool Success, Guid CustomerId, string Name, string GitHubUserName) UpdateCustomer(UpdateCustomerDTO dto)
        {
            var command = new UpdateCustomerCommand
                (
                dto.Id,
                dto.Name,
                dto.Email,
                dto.GitHubUsername
                );
            _bus.SendCommand(command);
            if (command.Response.Success)
            {
                _messageQueueService.PublishMessageAsync<PublishRequest>(DomainToMessageMapper.ToCustomerResponse(command)).Wait();
            }
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
