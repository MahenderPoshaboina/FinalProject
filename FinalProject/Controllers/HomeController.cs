using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public UserDbEntities4 db = new UserDbEntities4();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application login page.";

            return View();
        }

        public ActionResult Signup( string name, string email, string password, string phoneNumber)
        {

            var user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                ViewBag.ErrorMessage = "Account already exists with the email";
                return View();
            }

            // Create a new user since the email is not found
            var newUser = new User
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                TeamCode = null,
                Password = password,

            };

            db.Users.Add(newUser);
            db.SaveChanges();

            // Redirect to login page after successful signup
            return RedirectToAction("login", "users");

        }

        public ActionResult CreateTeam()
        {
            ViewBag.Message = "Your createteam page.";

            return View();
        }
        public ActionResult Hackathon()
        {
            ViewBag.Message = "Your hackathon details page.";

            return View();
        }
      
        public ActionResult JoinTeam(int? teamCode)
        {
            string email = Session["Email"] as string;
            string password = Session["Password"] as string;
            if (email != null && password!= null)
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    if (user.TeamCode != null)
                    {
                        ViewBag.ErrorMessage = "You have already joined a team.";
                    }
                    else
                    {
                        var team = db.Teams.FirstOrDefault(t => t.TeamCode == teamCode);
                        if (team != null)
                        {
                            user.TeamCode = team.TeamCode;
                            db.SaveChanges();

                            ViewBag.SuccessMessage = "Joined team successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Team code does not exist.";
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }

            return View();
        }

        public ActionResult IdeaSubmission()
        {
            ViewBag.Message = "Your idea submission details page.";

            return View();
       }
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your idea submission details page.";

            return View();
        }
        public ActionResult TeamParticipants()
        {
            string email = Session["Email"] as string;
            string password = Session["Password"] as string;
            if (email == null || password == null)
            {
                ViewBag.Message = "Please login to view your teammates.";
                return RedirectToAction("Login", "Users");
            }

            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.Message = "Invalid email or password.";
                return RedirectToAction("Login", "Users");
            }

            var teamCode = user.TeamCode;
            if (teamCode == null)
            {
                ViewBag.Message = "You are not a member of any team.";
                return View();
            }

            var teammates = db.Users.Where(u => u.TeamCode == teamCode && u.Email != email).ToList();
            ViewBag.Teammates = teammates;

            return View();
        }

    }
}