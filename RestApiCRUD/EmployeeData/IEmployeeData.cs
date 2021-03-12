
using RestApiCRUD.Models;
using System;
using System.Collections.Generic;

namespace RestApiCRUD.EmployeeData
{
   public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        Employee AddEmployee(Employee EmpOB);

        void DeleteEmployee(Employee EmpOB);
        Employee EditEmployee(Employee EmpOB);
    }
}
