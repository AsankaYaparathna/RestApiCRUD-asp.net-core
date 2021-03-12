using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.EmployeeData;
using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.Controllers
{
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _IEmployeeData;
        public EmployeeController(IEmployeeData EmployeeData)
        {
            _IEmployeeData = EmployeeData;
        }

        [HttpGet]
        [Route("api/GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(_IEmployeeData.GetEmployees());
        }

        [HttpGet]   
        [Route("api/GetEmployee/{Id}")]
        public IActionResult GetEmployee(Guid Id)
        {
            var EmployeeCheack = _IEmployeeData.GetEmployee(Id);
            if (EmployeeCheack != null)
            {
                return Ok(EmployeeCheack);
            }
            else
            {
                return NotFound($"Employee with Id : {Id} was not found");
            }
        }

        [HttpPost]
        [Route("api/AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            _IEmployeeData.AddEmployee(employee);
  
            return Created(HttpContext.Request.Scheme + "//" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
            
        }

        [HttpDelete]
        [Route("api/DeleteEmployee/{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var EmployeeCheack = _IEmployeeData.GetEmployee(Id);
            if (EmployeeCheack != null)
            {
                _IEmployeeData.DeleteEmployee(EmployeeCheack);
                return Ok($"Successfully Deleted the ID : {Id}");
            }
             return NotFound($"Employee with Id : {Id} was not found");
            
        }

        [HttpPatch]
        [Route("api/EditEmployee/{Id}")]
        public IActionResult EditEmployee(Guid Id,Employee EmpOB)
        {
            var EmployeeCheack = _IEmployeeData.GetEmployee(Id);
            if (EmployeeCheack != null)
            {
                EmpOB.Id=EmployeeCheack.Id;
                _IEmployeeData.EditEmployee(EmpOB);
                
            }
            return Ok($"Successfully Updated the ID : {Id}");

        }
    }
}
