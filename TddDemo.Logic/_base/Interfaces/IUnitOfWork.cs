using System.Data.Entity.Core.Objects;
using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    public interface IUnitOfWork
    {
        IObjectSet<Employee> Employees { get; }
        IObjectSet<TimeCard> TimeCards { get; }
        void Commit();
    }
}