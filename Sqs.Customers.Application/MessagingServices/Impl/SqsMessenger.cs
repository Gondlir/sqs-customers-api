using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Infrastructure.MessagingQueue.Abstractions;
using System.Text.Json;

namespace Sqs.Customers.Application.MessagingServices.Impl
{
    public sealed class SqsMessenger : IMessagingQueueService
    {
        private readonly IAmazonSQS _awsSQS;
        private static AmazonSQSClient _awsClient = new AmazonSQSClient(RegionEndpoint.USEast1);
        private readonly IOptions<QueueSettings> _settings;
        private string? _queueUrl;
        public SqsMessenger(IAmazonSQS awsSQS, IOptions<QueueSettings> settings)
        {
            _awsSQS = awsSQS;
            _settings = settings;
        }

        public async Task<T> SendMessageAsync<T>(object message) where T : class
        {
            var queueUrl = await GetQueueUrlAsync();
            var sendMessage = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = JsonSerializer.Serialize(message),
                MessageAttributes = new Dictionary<string, MessageAttributeValue> {
                    {
                        "MessageType", new MessageAttributeValue
                        {
                            DataType = "String",
                            StringValue = message.ToString()
                        }
                    }
                }
            };
            //var result = await _awsSQS.SendMessageAsync(sendMessage) as T;
            try
            {
                var result = await _awsClient.SendMessageAsync(sendMessage) as T;
                return result!;
            }
            catch (Exception ex)
            {
                // Log Errors
                throw;
            }
            //add cancelation token perhaps?
        }
        #region Private Methods
        private async Task<string> GetQueueUrlAsync()
        {
            if (_queueUrl is not null)
            {
                return _queueUrl;
            }
            //var queueUrlResponse = await _awsSQS.GetQueueUrlAsync(_settings.Value.Name);
            var queueUrlResponse = await _awsClient.GetQueueUrlAsync(_settings.Value.Name);
            _queueUrl = queueUrlResponse.QueueUrl;
            return _queueUrl;
        }
        #endregion
        public void Dispose()
        {
            _awsSQS.Dispose();
            this.Dispose();
        }
    }
}
