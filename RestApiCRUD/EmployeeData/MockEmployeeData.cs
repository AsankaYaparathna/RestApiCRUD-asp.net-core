using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Employee one"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Employee two"
            }
        };

        public Employee AddEmployee(Employee EmpOB)
        {
            EmpOB.Id = Guid.NewGuid();
            employees.Add(EmpOB);
            return EmpOB;

        }

        public void DeleteEmployee(Employee EmpOB)
        {
            employees.Remove(EmpOB);
        }

        public Employee EditEmployee(Employee EmpOB)
        {
            var ExistEmployee = GetEmployee(EmpOB.Id);
            ExistEmployee.Name = EmpOB.Name;
            return ExistEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
