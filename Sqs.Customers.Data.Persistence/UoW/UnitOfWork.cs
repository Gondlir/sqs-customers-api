using Sqs.Customers.Data.Migrations.Context;
using Sqs.Customers.Domain.Abstractions.Interfaces;

namespace Sqs.Customers.Data.Persistence.UoW
{
    public sealed class UnitOfWork : IUoW
    {
        // inject EF Core persistence context
        private readonly EntityFrameworkContext _context;

        public UnitOfWork(EntityFrameworkContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            int rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;    
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
