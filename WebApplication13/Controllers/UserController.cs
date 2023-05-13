using System;
using System.Collections.Generic;
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
            // check if the provided email and password match a user in the database
            var dbUser = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (dbUser == null)
            {
                // if no matching user was found, display an error message and return the login view
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("Login");
            }
            else
            {
                // if the user was found, store their ID in a session variable
                Session["UserId"] = dbUser.Id;

                // display a success message and redirect to the Employees page
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "Employees");
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
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "User");
            }

            ViewBag.DepartmentList = new SelectList(db.Departments.ToList(), "Id", "Name");
            return View(user);
        }
    }

}