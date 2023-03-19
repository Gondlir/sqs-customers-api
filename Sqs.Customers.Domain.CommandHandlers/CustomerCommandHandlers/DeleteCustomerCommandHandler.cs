using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using System.Transactions;

namespace Sqs.Customers.Domain.CommandHandlers.CustomerCommandHandlers
{
    public sealed class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUoW _uow;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUoW uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public void Handle(DeleteCustomerCommand @event)
        {
            using (var scope = new TransactionScope()) 
            {
                try
                {
                    var customer = _customerRepository.GetById(@event.Id);
                    if (customer is null)
                        return;

                    _customerRepository.Delete(customer);
                    _uow.Commit();
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    // Logg erros
                    scope.Dispose();
                    throw;
                }
            }
        }
    }
}
