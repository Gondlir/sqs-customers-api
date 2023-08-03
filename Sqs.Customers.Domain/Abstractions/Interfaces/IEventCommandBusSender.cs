using Sqs.Customers.Domain.Abstractions.Commands;

namespace Sqs.Customers.Domain.Abstractions.Interfaces
{  
    public interface IEventCommandBusSender
    {
        void SendCommand<T>(T command) where T : ICommand;
    }
}
