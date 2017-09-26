using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CoursesController : Controller
    {
        private CoursesContext database = new CoursesContext();
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string name)
        {
            var category = database.Categories.Include("Courses")
                                              .Where(x => x.Name.ToUpper() == name.ToUpper()).Single();

            var courses = category.Courses.ToList();

            return View(courses);
        }

        public ActionResult Details(int id)
        {
            var course = database.Courses.Find(id);

            return View(course);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult CategoriesMenu()
        {
            var categories = database.Categories.ToList();
            return PartialView("_CategoriesMenu",categories);
        }
    }
}