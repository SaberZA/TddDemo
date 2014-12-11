using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    public interface IUnitOfWork
    {
        IDbSet<Employee> Employees { get; }
        IDbSet<TimeCard> TimeCards { get; }
        void Commit();
    }
}