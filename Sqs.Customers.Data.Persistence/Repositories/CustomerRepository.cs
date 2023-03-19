using Sqs.Customers.Data.Migrations.Context;
using Sqs.Customers.Data.Persistence.CommomBase;
using Sqs.Customers.Domain.Entities.Customers;

namespace Sqs.Customers.Data.Persistence.Repositories
{
    public sealed class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EntityFrameworkContext efContext) : base(efContext)
        {

        }
        public Customer GetById(Guid id)
        {
           return base.GetById(id);
        }

        IQueryable<Customer> ICustomerRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
