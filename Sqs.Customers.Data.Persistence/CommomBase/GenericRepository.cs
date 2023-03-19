using Microsoft.EntityFrameworkCore;
using Sqs.Customers.Data.Migrations.Context;

namespace Sqs.Customers.Data.Persistence.CommomBase
{
    public abstract class GenericRepository<T> where T : class
    {
        protected EntityFrameworkContext _context;
        protected DbSet<T> dbSet;

        protected GenericRepository(EntityFrameworkContext context)
        {
            this._context = context;
            this.dbSet = context.Set<T>();
        }

        protected IQueryable<T> Table 
        {
            get { return dbSet; }
        }
        public virtual IEnumerable<T> GetAll() 
        {
            return dbSet.ToList();
        }
        public virtual T GetById(object id) 
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(T entity) 
        {
            dbSet.Add(entity);
        }
        public virtual void Delete(object id) 
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(T entityToDelete) 
        {
            if(_context.Entry(entityToDelete).State == EntityState.Detached) 
            {
                dbSet.Attach(entityToDelete);   
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(T entityToUpdate) 
        {
            dbSet.Attach(entityToUpdate);
            dbSet.Entry(entityToUpdate).State = EntityState.Modified; 
        }
        public virtual void Dispose() 
        {
            this._context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
