using System.Configuration;
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
            //var connectionString =
            //    ConfigurationManager
            //        .ConnectionStrings[ConnectionStringName]
            //        .ConnectionString;
            var connString = getConStrSQL();
            _context = new ObjectContext(connString);
             
            Committed = false;
        }

        public IObjectSet<Employee> Employees
        {
            get { return _context.CreateObjectSet<Employee>(); }
        }
        
        public IObjectSet<TimeCard> TimeCards
        {
            get { return _context.CreateObjectSet<TimeCard>(); }
        }

        public bool Committed { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
            Committed = true;
        }

        readonly ObjectContext _context;
        const string ConnectionStringName = "EmployeeDataModelContainer";

        public static string getConStrSQL()
        {
            string connectionString = new EntityConnectionStringBuilder
            {
                Metadata = @"res://*/",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
                {
                    InitialCatalog = ConnectionStringName,
                    DataSource = @".\SQLEXPRESS",
                    IntegratedSecurity = true,
                }.ConnectionString
            }.ConnectionString;

            return connectionString;
        }
    }

    public class LocalContext : ObjectContext
    {
        public LocalContext(string connectionStringName)
            : base("name=" + connectionStringName)
        {
            
        }

        
    }
}