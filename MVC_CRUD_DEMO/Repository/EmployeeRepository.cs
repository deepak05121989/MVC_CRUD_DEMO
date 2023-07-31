using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MVC_CRUD_DEMO.Models;

namespace MVC_CRUD_DEMO.Repository
{
    public class EmployeeRepository
    {
        private readonly SqlConnection sqlConnection;
        private readonly SqlCommand sqlCommand;

        public EmployeeRepository()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);
            sqlCommand = new SqlCommand();

        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> empList = new List<Employee>();
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "select [emp_id], [emp_name], [emp_email], [emp_salary], [emp_dept] from Employees";
                sqlCommand.Connection = sqlConnection;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        EmployeeId = Convert.ToInt32(reader["emp_id"].ToString()),
                        EmployeeEmail = reader["emp_email"].ToString(),
                        EmployeeName = reader["emp_name"].ToString(),
                        EmployeeDepartment = reader["emp_dept"].ToString(),
                        EmployeeSalary = Convert.ToDouble(reader["emp_salary"].ToString())
                    };
                    empList.Add(employee);

                }

            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return empList;


        }
        public Employee GetEmployeeById(int empId)
        {
            Employee emp = new Employee();
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "select [emp_id], [emp_name], [emp_email], [emp_salary], [emp_dept] from Employees where emp_id=@emp_id";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@emp_id", empId);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    emp.EmployeeId = Convert.ToInt32(reader["emp_id"].ToString());
                    emp.EmployeeEmail = reader["emp_email"].ToString();
                    emp.EmployeeName = reader["emp_name"].ToString();
                    emp.EmployeeDepartment = reader["emp_dept"].ToString();
                    emp.EmployeeSalary = Convert.ToDouble(reader["emp_salary"].ToString());
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return emp;


        }
        public int AddEmployee(Employee employee)
        {
            int result;
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "insert into employees([emp_name], [emp_email], [emp_salary], [emp_dept]) values(@emp_name,@emp_email,@emp_salary,@emp_dept)";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@emp_name", employee.EmployeeName);
                sqlCommand.Parameters.AddWithValue("@emp_email", employee.EmployeeEmail);
                sqlCommand.Parameters.AddWithValue("@emp_salary", employee.EmployeeSalary);
                sqlCommand.Parameters.AddWithValue("@emp_dept", employee.EmployeeDepartment);
                result = sqlCommand.ExecuteNonQuery();
                if(result>0)
                {
                    return result;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;


        }
        public int EditEmployee(int empId,Employee employee)
        {
            int result;
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "update employees set [emp_name]=@emp_name, [emp_email]=@emp_email, [emp_salary]=@emp_salary, [emp_dept]=@emp_dept where emp_id=@emp_id";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@emp_id", empId);
                sqlCommand.Parameters.AddWithValue("@emp_name", employee.EmployeeName);
                sqlCommand.Parameters.AddWithValue("@emp_email", employee.EmployeeEmail);
                sqlCommand.Parameters.AddWithValue("@emp_salary", employee.EmployeeSalary);
                sqlCommand.Parameters.AddWithValue("@emp_dept", employee.EmployeeDepartment);
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return result;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;


        }
        public int DeleteEmployee(int empId)
        {
            int result;
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "delete from employees where emp_id=@emp_id";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@emp_id", empId);
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return result;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;


        }




    }
}