using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Options;
using Sqs.Infrastructure.MessagingQueue.Abstractions;
using System.Text.Json;

namespace Sqs.Customers.Application.MessagingServices.Impl
{
    public sealed class SnsMessenger : IMessagingQueueService
    {
        private static AmazonSimpleNotificationServiceClient _awsSnS = new AmazonSimpleNotificationServiceClient(RegionEndpoint.USEast1);
        private readonly IOptions<QueueSettings> _topicSettings;
        private string? _topicArn;
        public SnsMessenger(IOptions<QueueSettings> settings)
        {
            _topicSettings = settings;
        }

        public async Task<T> PublishMessageAsync<T>(object message) where T : class
        {
            var topicArn = await GetTopicArnAsync();
            var sendMessage = new PublishRequest
            {
                TopicArn = topicArn,
                Message = JsonSerializer.Serialize(message),
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
           
            try
            {
                var result = await _awsSnS.PublishAsync(sendMessage) as T;
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
        private async ValueTask<string> GetTopicArnAsync()
        {
            if (_topicArn is not null)
            {
                return _topicArn;
            }
            var topicArnResponse = await _awsSnS.FindTopicAsync(_topicSettings.Value.Name);
            _topicArn = topicArnResponse.TopicArn;
            return _topicArn;
        }
        #endregion
        public void Dispose()
        {
            _awsSnS.Dispose();
            this.Dispose();
        }
    }
}
