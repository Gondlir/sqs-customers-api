using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using Sqs.Infrastructure.DTO;

namespace Sqs.Customers.Application.MessagingServices
{
    public static class DomainToMessageMapper
    {
     // create a contract  ??
     // mudar nome da classe talvez ?? 
        public static CustomerCreated ToCustomerResponse(this CreateCustomerCommand command) 
        {
            return new CustomerCreated
            {
                Id = command.Response.CustomerId,
                Name = command.Name,
                Email = command.Email,
                GitHubUsername = command.GitHubUsername
            };
        }
        public static CustomerUpdated ToCustomerResponse(this UpdateCustomerCommand command)
        {
            return new CustomerUpdated
            {
                Id = command.Response.CustomerId,
                Name = command.Name,
                Email = command.Email,
                GitHubUsername = command.GitHubUsername
            };
        }
        public static CustomerDeleted ToCustomerResponse(this DeleteCustomerCommand command)
        {
            return new CustomerDeleted
            {
                Id = command.Id,
            };
        }
    }
}
