using MVC_CRUD_DEMO.Models;
using MVC_CRUD_DEMO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_DEMO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeServives empservives;
        public EmployeeController()
        {
            empservives = new EmployeeServives();
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees=empservives.GetAllEmployee();

            }
            catch(Exception ex)
            {

            }

            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = new Employee();
            try
            {
                employee = empservives.GetEmployeeById(id);

            }
            catch (Exception ex)
            {

            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            int result;
            try
            {
                result = empservives.CreateEmployee(employee);
                if(result>0)
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();
            try
            {
                employee = empservives.GetEmployeeById(id);

            }
            catch (Exception ex)
            {

            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            int result;
            try
            {
                result = empservives.UpdateEmployee(id,employee);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = new Employee();
            try
            {
                employee = empservives.GetEmployeeById(id);

            }
            catch (Exception ex)
            {

            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int result;
            try
            {
                result = empservives.DeleteEmployee(id);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
