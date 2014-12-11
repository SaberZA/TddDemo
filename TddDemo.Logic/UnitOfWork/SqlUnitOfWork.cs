using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using TddDemo.Logic.Models;
using TddDemo.Test;

namespace TddDemo.Logic.UnitOfWork
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        public SqlUnitOfWork()
        {
            var connectionString =
                ConfigurationManager
                    .ConnectionStrings[ConnectionStringName]
                    .ConnectionString;
            //var connectionString = getConStrSQL();
            _context = new LocalDbContext(connectionString);
             
            Committed = false;
        }

        public IDbSet<Employee> Employees
        {
            get { return _context.Set<Employee>(); }
        }

        public IDbSet<TimeCard> TimeCards
        {
            get { return _context.Set<TimeCard>(); }
        }

        public bool Committed { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
            Committed = true;
        }

        readonly LocalDbContext _context;
        const string ConnectionStringName = "EmployeeDataModelContainer";
    }
}