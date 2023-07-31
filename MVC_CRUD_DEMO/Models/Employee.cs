using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DEMO.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public double EmployeeSalary { get; set; }
        public string EmployeeDepartment { get; set; }
    }
}