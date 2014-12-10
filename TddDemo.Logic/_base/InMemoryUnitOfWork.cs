using System.Data.Entity.Core.Objects;
using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public InMemoryUnitOfWork()
        {
            Committed = false;
        }
        public IObjectSet<Employee> Employees
        {
            get;
            set;
        }

        public IObjectSet<TimeCard> TimeCards
        {
            get;
            set;
        }

        public bool Committed { get; set; }
        public void Commit()
        {
            Committed = true;
        }
    }
}