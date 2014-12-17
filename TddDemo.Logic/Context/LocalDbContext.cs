using System.Data.Entity;
using TddDemo.Logic.Models;

namespace TddDemo.Logic.UnitOfWork
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LocalDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}