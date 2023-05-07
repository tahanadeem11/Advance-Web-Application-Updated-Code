﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmpContext employeeContext = new EmpContext();
            List<Department> departments = employeeContext.Departments.ToList();
            return View(departments);
        }

    }
}