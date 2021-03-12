using RestApiCRUD.Data;
using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData 
    {
        private EmployeeDataContext _employeeDataContext;

        public SqlEmployeeData(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }

        public Employee AddEmployee(Employee EmpOB)
        {
            EmpOB.Id = Guid.NewGuid();
            _employeeDataContext.employeeDB.Add(EmpOB);
            _employeeDataContext.SaveChanges();
            return EmpOB;
        }

        public void DeleteEmployee(Employee EmpOB)
        {
            _employeeDataContext.employeeDB.Remove(EmpOB);
            _employeeDataContext.SaveChanges();
        }

        public Employee EditEmployee(Employee EmpOB)
        {
            var ExistEmployee = GetEmployee(EmpOB.Id);

            if (ExistEmployee != null)
            {
                ExistEmployee.Name = EmpOB.Name;
                _employeeDataContext.employeeDB.Update(ExistEmployee);
                _employeeDataContext.SaveChanges();
            }
            return ExistEmployee;

        }

        public Employee GetEmployee(Guid id)
        {
            var EmpOB = _employeeDataContext.employeeDB.Find(id);

            return EmpOB;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeDataContext.employeeDB.ToList();
        }
    }
}
