using Sqs.Customers.Domain.Abstractions.Commands;

namespace Sqs.Customers.Domain.Entities.Customers.Commands
{
    public sealed class DeleteCustomerCommand : ICommand
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
        public bool Success { get; set; }
    }
}
