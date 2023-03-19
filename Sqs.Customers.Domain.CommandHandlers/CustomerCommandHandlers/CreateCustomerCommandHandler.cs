using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;

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
            throw new NotImplementedException();
        }
    }
}
