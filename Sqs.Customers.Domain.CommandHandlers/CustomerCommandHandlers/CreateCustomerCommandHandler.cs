using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using System.Transactions;

namespace Sqs.Customers.Domain.CommandHandlers.CustomerCommandHandlers
{
    public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUoW _uow;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUoW uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public void Handle(CreateCustomerCommand @event)
        {
            using (var scope = new TransactionScope()) 
            {
                try
                {
                    var customer = new Customer
                 (@event.Name,
                 @event.Email,
                 @event.GitHubUsername);
                    _customerRepository.Insert(customer);
                    _uow.Commit();
                    @event.Response = (CustomerId: customer.Id, Name: customer.Name, GitHubUserName: customer.GitHubUsername);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    // Log errors
                    scope.Dispose();
                    throw;
                }
            }
        }
    }
}
