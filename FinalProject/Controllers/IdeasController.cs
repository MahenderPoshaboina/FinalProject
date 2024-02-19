using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Data.Entity.Infrastructure;



namespace FinalProject.Controllers
{
    public class IdeasController : Controller
    {
        private UserDbEntities3 db = new UserDbEntities3();

        // GET: Ideas
     

        // GET: Ideas/Details/5
        public ActionResult Details()
        {
            var ideas = db.Ideas.ToList();
            return View("Details", ideas);
        }

        // GET: Ideas/Create
        public ActionResult IdeaSubmission()
        {
            ViewBag.TeamCode = new SelectList(db.Teams, "TeamCode", "TeamName");
            return View();
        }

        // POST: Ideas/Create
        [HttpPost]
        public ActionResult IdeaSubmission(Idea idea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Ideas.Add(idea);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                // If ModelState is not valid, return the view with errors
                ViewBag.Error = "Model state is not valid.";
                db.Ideas.Add(idea);
                db.SaveChanges();
                return View(idea);
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Exception innerException = ex.InnerException;

                while (innerException != null)
                {
                    // Log or inspect the inner exception
                    innerException = innerException.InnerException;
                }

                ViewBag.Error = "An error occurred while saving the data.";
                return View(idea);
            }
            catch (Exception ex)
            {
                // Handle or log other exceptions
                ViewBag.Error = "An unexpected error occurred.";
                return View(idea);
            }
        }




        // ... (Your existing actions)

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}