using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using System.Transactions;

namespace Sqs.Customers.Domain.CommandHandlers.CustomerCommandHandlers
{
    public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly IUoW _uow;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(IUoW uow, ICustomerRepository customerRepository)
        {
            _uow = uow;
            _customerRepository = customerRepository;
        }

        public void Handle(UpdateCustomerCommand @event)
        {
            using (var scope = new TransactionScope()) 
            {
                try
                {
                    var customer = _customerRepository.GetById(@event.Id);
                    if (customer is null)
                        return;
                    customer.AddName(@event.Name);
                    customer.AddEmail(@event.Email);
                    customer.AddGitHubUserName(@event.GitHubUsername);
                    _customerRepository.Update(customer);
                    _uow.Commit();
                    @event.Response = (CustomerId: customer.Id, Name: customer.Name, GitHubUserName: customer.GitHubUsername);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    // Log erros
                    scope.Dispose();
                    throw;
                }
            }
                

        }
    }
}
