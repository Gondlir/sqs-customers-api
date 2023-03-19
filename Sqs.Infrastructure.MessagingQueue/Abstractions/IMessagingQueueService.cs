﻿using Sqs.Customers.Domain.Abstractions.Commands;

namespace Sqs.Infrastructure.MessagingQueue.Abstractions
{
    public interface IMessagingQueueService : IDisposable
    {
        Task<T> SendMessageAsync<T>(ICommand message) where T : class;
    }
}
