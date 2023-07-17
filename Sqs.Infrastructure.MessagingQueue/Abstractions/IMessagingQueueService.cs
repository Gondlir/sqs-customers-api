using Sqs.Customers.Domain.Abstractions.Commands;

namespace Sqs.Infrastructure.MessagingQueue.Abstractions
{
    public interface IMessagingQueueService : IDisposable
    {
        Task<T> PublishMessageAsync<T>(object message) where T : class;
    }
}
