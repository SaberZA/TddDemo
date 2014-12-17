using System;
using System.Collections.Generic;
using TddDemo.Logic.Models;

namespace TddDemo.Test
{
    public static class EmployeeObjectMother
    {
        public static IEnumerable<Employee> CreateEmployees()
        {
            yield return new Employee()
            {
                Id = 1,
                Name = "Karel",
                HireDate = new DateTime(2002, 1, 1)
            };
            yield return new Employee()
            {
                Id = 2,
                Name = "Divan",
                HireDate = new DateTime(2001, 1, 1)
            };
            yield return new Employee()
            {
                Id = 3,
                Name = "Steven",
                HireDate = new DateTime(2008, 1, 1)
            };
        }
    }
}