using System.Collections.Generic;
using System.Linq;
using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    public class EmployeeControllerTestBase
    {
        public EmployeeControllerTestBase()
        {
            EmployeeData = EmployeeObjectMother.CreateEmployees()
                .ToList();
            Repository = new InMemoryObjectSet<Employee>(EmployeeData);
            UnitOfWork = new InMemoryUnitOfWork {Employees = Repository};
            Controller = new EmployeeController(UnitOfWork);
        }

        protected IList<Employee> EmployeeData;
        protected EmployeeController Controller;
        protected InMemoryObjectSet<Employee> Repository;
        protected InMemoryUnitOfWork UnitOfWork;
    }
}