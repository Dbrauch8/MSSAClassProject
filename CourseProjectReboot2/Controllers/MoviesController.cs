using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProjectReboot2.Models;

namespace CourseProjectReboot2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name =  "Shreck!" };

            //return View(movie);
            //return Content("Hello World");
            return HttpNotFound();
        }
    }
}