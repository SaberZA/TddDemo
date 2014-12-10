using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    public class ViewResult
    {
        private readonly Employee _employee;

        public ViewResult(Employee employee)
        {
            _employee = employee;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, HireDate: {1}, Id: {2}", _employee.Name, _employee.HireDate, _employee.Id);
        }
    }
}