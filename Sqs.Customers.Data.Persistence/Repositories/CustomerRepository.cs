using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Sqs.Customers.Data.Migrations.Context;
using Sqs.Customers.Data.Persistence.CommomBase;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Infrastructure.DTO;
using System.Text.Json;

namespace Sqs.Customers.Data.Persistence.Repositories
{
    public sealed class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly IAmazonDynamoDB _dynamoDB;
        private readonly string _tableName = "customers";
        public CustomerRepository(IAmazonDynamoDB dynamoDB, EntityFrameworkContext efContext) : base(efContext)
        {
           AmazonDynamoDBConfig config = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.USEast1
           };

            _dynamoDB = new AmazonDynamoDBClient(config);
            
        }

        public void CreateWithDynamoDB(Customer dto)
        {
            //dto.UpdateAt = DateTime.UtcNow;
            
            var customerAsJson = JsonSerializer.Serialize(dto);
            var customerAsAttributes = Document.FromJson(customerAsJson).ToAttributeMap();

            var createItemRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = customerAsAttributes
            };

            var response =  _dynamoDB.PutItemAsync(createItemRequest).Result;
        }

        public Customer GetById(Guid id)
        {
           return base.GetById(id);
        }

        public Customer GetByIdDynamoDb(Guid id)
        {
            var getItemRequest = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue> 
                {
                    { "pk", new AttributeValue { S = id.ToString() } },
                    { "sk", new AttributeValue { S = id.ToString() } }
                }
            };
            var response = _dynamoDB.GetItemAsync(getItemRequest).Result;
            var itemAsDocument = Document.FromAttributeMap(response.Item);
            return JsonSerializer.Deserialize<Customer>(itemAsDocument);
        }

        IQueryable<Customer> ICustomerRepository.GetAll()
        {
            throw new NotImplementedException();
        }
        public void DelteCustomerDynamoDb(Guid id) 
        {
            var deleteItemRequest = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "pk", new AttributeValue { S = id.ToString() } },
                    { "sk", new AttributeValue { S = id.ToString() } }
                }
            };
            var response = _dynamoDB.DeleteItemAsync(deleteItemRequest).Result;
        }
    }
}
