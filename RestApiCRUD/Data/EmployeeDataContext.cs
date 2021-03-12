using Microsoft.EntityFrameworkCore;
using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.Data
{
    public class EmployeeDataContext:DbContext
    {
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext>options):base(options)
        {

        }
        public DbSet<Employee> employeeDB { get; set;  }
    }
}
