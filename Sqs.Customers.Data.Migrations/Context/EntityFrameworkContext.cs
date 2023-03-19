using Microsoft.EntityFrameworkCore;
using Sqs.Customers.Data.Migrations.EntityMapping;
using Sqs.Customers.Domain.Entities.Customers;
using System.Drawing;

namespace Sqs.Customers.Data.Migrations.Context
{
    public sealed class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext()
        {

        }
        public EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> opt) : base (opt)
        {

        }
        #region DbSets
        public DbSet<Customer> Customers { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            // Customer Domain
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }
        //adicionar OnConfiguring
    }
}
