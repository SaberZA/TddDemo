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
            Repository = new InMemoryDbSet<Employee>(EmployeeData);
            UnitOfWork = new InMemoryUnitOfWork {Employees = Repository};
            Controller = new EmployeeController(UnitOfWork);
        }

        protected IList<Employee> EmployeeData;
        protected EmployeeController Controller;
        protected InMemoryDbSet<Employee> Repository;
        protected InMemoryUnitOfWork UnitOfWork;
    }
}