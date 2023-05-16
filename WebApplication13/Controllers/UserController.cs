using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class UserController : Controller
    {
        private EmpContext db = new EmpContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            // check if the user is in the database
            var userInDb = db.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (userInDb != null)
            {
                // set the user's ID in the session
                Session["UserId"] = userInDb.Id;

                // redirect to the Employees page
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                // display an error message
                ModelState.AddModelError("", "Invalid email or password.");
                return View(user);
            }
        }



        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.DepartmentList = new SelectList(db.Departments.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "User");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var error in ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors))
                    {
                        // Log the error using a logging framework like Serilog
                        // You can also display the error message using ViewBag and display it in the view
                    }
                }
            }

            ViewBag.DepartmentList = new SelectList(db.Departments.ToList(), "Id", "Name");
            return View(user);
        }

    }

}