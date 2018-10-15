using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
using System.Data;
namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Employee(int id)
        {
            Employee emp = new Employee();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetEmployee(id);
            if (dt.Rows.Count > 0)
            {
                emp.EmployeeId = Convert.ToInt32(dt.Rows[0]["EmpId"]);
                emp.EmployeeName = dt.Rows[0]["EmpName"].ToString();
                emp.Location = dt.Rows[0]["Location"].ToString();
            }
            ViewData["emp"] = emp;
            return View("EmployeeForm");
        }
        public ActionResult New()
        {
            return View("EmployeeForm");
        }

        public ActionResult Employees()
        {
            List<Employee> employees = new List<Employee>();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetEmployees();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dr["Empid"]);
                    emp.EmployeeName = dr["EmpName"].ToString();
                    emp.Location = dr["Location"].ToString();
                    employees.Add(emp);
                }
            }
            return View("Employees", employees);
        }

        public ActionResult Edit(int employeeId)
        {
           
            Employee emp = new Employee();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetEmployee(employeeId);
            if (dt.Rows.Count > 0)
            {
                emp.EmployeeId = Convert.ToInt32(dt.Rows[0]["EmpId"]);
                emp.EmployeeName = dt.Rows[0]["EmpName"].ToString();
                emp.Location = dt.Rows[0]["Location"].ToString();
            }
            ViewData["emp"] = emp;
            return View("EmployeeForm", emp);
        }
        public ActionResult Update(Employee employee)
        {
            DbAccess db = new DbAccess();
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                    db.SaveEmployee(employee, true);
                else
                    db.SaveEmployee(employee, false);
                return RedirectToAction("employees", "Employee");
            }
            else
              
            return View("EmployeeForm",employee);
        }
        //public ActionResult AddNew(Employee employee)
        //{
        //    DbAccess db = new DbAccess();
        //    if (ModelState.IsValid)
        //    {
        //        db.SaveEmployee(employee, true);
        //        return RedirectToAction("employees", "employee");
        //    }
        //    else
        //        return View("EmployeeForm", employee);
        //}
        public ActionResult deleteEmployee(int id)
        {
            DbAccess db = new DbAccess();
            db.DeleteEmployee(id);
            return RedirectToAction("employees", "employee");
        }
    }
}