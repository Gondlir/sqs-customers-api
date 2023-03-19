using Sqs.Customers.Domain.Abstractions.Interfaces;

namespace Sqs.Customers.Data.Persistence.UoW
{
    public sealed class UnitOfWork : IUoW
    {
        // inject EF Core persistence context
        public bool Commit()
        {
            return true;
        }

        public void Dispose()
        {
            
        }
    }
}
