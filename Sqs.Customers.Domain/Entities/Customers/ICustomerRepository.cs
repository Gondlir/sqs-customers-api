using Sqs.Infrastructure.DTO;

namespace Sqs.Customers.Domain.Entities.Customers
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        Customer GetByIdDynamoDb(Guid id);
        void CreateWithDynamoDB(Customer dto);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        IQueryable<Customer> GetAll();
    }
}
