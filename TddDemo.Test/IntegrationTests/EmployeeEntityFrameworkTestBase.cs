using System.Collections.Generic;
using System.Linq;
using TddDemo.Logic.Models;
using TddDemo.Logic.UnitOfWork;

namespace TddDemo.Test
{
    public class EmployeeEntityFrameworkTestBase
    {
        public EmployeeEntityFrameworkTestBase()
        {
            EmployeeData = EmployeeObjectMother.CreateEmployees()
                .ToList();
            UnitOfWork = new SqlUnitOfWork();
            Controller = new EmployeeController(UnitOfWork);
        }

        protected IList<Employee> EmployeeData;
        protected EmployeeController Controller;
        protected SqlUnitOfWork UnitOfWork;
    }
}