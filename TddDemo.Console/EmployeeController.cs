using System.Linq;
using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    public class EmployeeController : Controller {
        private IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)  {
            _unitOfWork = unitOfWork;
        }

        public void Create(Employee newEmployee)
        {
            _unitOfWork.Employees.AddObject(newEmployee);
            _unitOfWork.Commit();
        }

        public ViewResult Details(int id)
        {
            var employee = _unitOfWork.Employees
                                      .First(e => e.Id == id);
            return View(employee);
        }



        // Fake Controller View Method
        private ViewResult View(Employee employee)
        {
            return new ViewResult(employee);
        }
    }
}