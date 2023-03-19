namespace Sqs.Customers.Domain.Abstractions.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T @event);
    }
}
