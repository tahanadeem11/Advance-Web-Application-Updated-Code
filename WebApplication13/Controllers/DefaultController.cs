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
        public ActionResult Index()

        {

            EmpContext employeeContext = new EmpContext();

            List<Employee> employees = employeeContext.Employees.ToList();

            return View(employees);

        }
    }
}