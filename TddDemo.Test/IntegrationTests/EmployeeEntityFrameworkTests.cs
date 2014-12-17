using System.Linq;
using NUnit.Framework;
using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    [TestFixture]
    public class EmployeeEntityFrameworkTests 
        : EmployeeEntityFrameworkTestBase
    {
        [Test]
        public void ShouldAddNewEmployeeToRepository()
        {
            Controller.Create(_newEmployee);
            Assert.IsTrue(UnitOfWork.Employees.Any(e => e.Id.Equals(_newEmployee.Id)));
        }

        [Test]
        public void ShouldCommitUnitOfWork()
        {
            Controller.Create(_newEmployee);
            Assert.IsTrue(UnitOfWork.Committed);
        }

        [Test]
        public void Details_GivenController_ShouldReturnEmployeeDetails()
        {
            //---------------Set up test pack-------------------
            Controller.Create(_newEmployee);
            //---------------Assert Precondition----------------
            Assert.IsTrue(UnitOfWork.Employees.Any(e=>e.Id.Equals(_newEmployee.Id)));
            //---------------Execute Test ----------------------
            var viewResult = Controller.Details(_newEmployee.Id);
            //---------------Test Result -----------------------
            Assert.AreEqual(viewResult.ToString(), "Name: NEW EMPLOYEE, HireDate: 1/1/2010 12:00:00 AM");
        }

        [TearDown]
        public void IndividualTestTearDown()
        {
            UnitOfWork.Employees.Remove(_newEmployee);
        }


        Employee _newEmployee = new Employee()
        {
            Name = "NEW EMPLOYEE",
            HireDate = new System.DateTime(2010, 1, 1)
        };
    }
}