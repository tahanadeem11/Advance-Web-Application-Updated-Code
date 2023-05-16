using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;
using WebApplication13.Controllers;
namespace WebApplication13.Controllers
{
    public class DefaultController : Controller
    {

        public ActionResult Index(int departmentId =0)
        {
            EmpContext employeeContext = new EmpContext();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();
            return View(employees);
        }



        public ActionResult Detail(int id)
        {
            EmpContext employeeContext = new EmpContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.id == id);

            return View(employee);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Testimonials()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}