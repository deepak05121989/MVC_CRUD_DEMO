using MVC_CRUD_DEMO.Models;
using MVC_CRUD_DEMO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DEMO.Services
{
    public class EmployeeServives
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeServives()
        {
            employeeRepository=new EmployeeRepository();
        }

        public List<Employee> GetAllEmployee()
        {
            try
            {
               return employeeRepository.GetAllEmployee();

            }
            catch
            {
                throw;
            }

        }
        public Employee GetEmployeeById(int empId)
        {
            try
            {
                return employeeRepository.GetEmployeeById(empId);

            }
            catch
            {
                throw;
            }

        }
        public int CreateEmployee(Employee employee)
        {
            try
            {
                return employeeRepository.AddEmployee(employee);

            }
            catch
            {
                throw;
            }

        }
        public int UpdateEmployee(int empId,Employee employee)
        {
            try
            {
                return employeeRepository.EditEmployee(empId,employee);

            }
            catch
            {
                throw;
            }

        }
        public int DeleteEmployee(int empId)
        {
            try
            {
                return employeeRepository.DeleteEmployee(empId);

            }
            catch
            {
                throw;
            }

        }

    }
}