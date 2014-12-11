using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TddDemo.Logic.Models;
using TddDemo.Test;

namespace TddDemo.Test
{

    [TestFixture]
    public class EmployeeControllerCreateActionPostTests
               : EmployeeControllerTestBase
    {

        [Test]
        public void ShouldAddNewEmployeeToRepository()
        {
            Controller.Create(_newEmployee);
            //Assert.IsTrue(UnitOfWork.Employees.Any(e=>e.Id == _newEmployee.Id));
            var enumerator = Repository.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current.Id);
            }
            //foreach (var employee in Repository)
            //{
            //    Debug.WriteLine(employee.Id);
            //}
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
            Assert.IsTrue(Repository.Any(e=>e.Id.Equals(_newEmployee.Id)));
            //---------------Execute Test ----------------------
            var viewResult = Controller.Details(_newEmployee.Id);
            //---------------Test Result -----------------------
            Assert.AreEqual(viewResult.ToString(), "Name: NEW EMPLOYEE, HireDate: 1/1/2010 12:00:00 AM, Id: 4");
        }


        Employee _newEmployee = new Employee()
        {
            Id = 4,
            Name = "NEW EMPLOYEE",
            HireDate = new System.DateTime(2010, 1, 1)
        };

        
    }
}
