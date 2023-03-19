namespace Sqs.Customers.Domain.Entities.Customers
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        IQueryable<Customer> GetAll();
    }
}
