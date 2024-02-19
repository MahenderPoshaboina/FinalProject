using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private UserDbEntities4 db = new UserDbEntities4();

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            // Here you would check the credentials against your database or other storage
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                // If the credentials are correct, save them in the session
                Session["Email"] = email;
                return RedirectToAction("Index", "Home"); // Redirect to a different page
            }
            ViewBag.ErrorMessage = "Incorrect email or password. Please try again.";
            return View();
        }
        

    }
}

