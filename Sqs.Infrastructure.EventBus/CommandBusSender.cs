using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Abstractions.Interfaces;

namespace Sqs.Infrastructure.EventBus
{
    public sealed class CommandBusSender : IEventCommandBusSender
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandBusSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            if (_serviceProvider == null)
                return;
            var commandHandler = GetServices<ICommandHandler<T>>().FirstOrDefault()!;
            commandHandler.Handle(command);
        }
        #region Private Methods
        private IEnumerable<T> GetServices<T>() 
        {
            return (IEnumerable<T>)_serviceProvider.GetService(typeof(IEnumerable<T>))!;
        }
        #endregion
    }
}
