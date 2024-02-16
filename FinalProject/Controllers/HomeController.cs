using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application login page.";

            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.Message = "Your signup page.";

            return View();
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
        public ActionResult JoinTeam()
        {
            ViewBag.Message = "Your hackathon details page.";

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
    }
}