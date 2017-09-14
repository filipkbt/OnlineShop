using OnlineShop.DAL;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private CoursesContext database = new CoursesContext();
        // GET: Home
        public ActionResult Index()
        {
            var categories = database.Categories.ToList();

            var newCourses = database.Courses.Where(x => !x.Hidden)
                                             .OrderByDescending(x => x.AddDate)
                                             .Take(3)
                                             .ToList();

            var bestsellers = database.Courses.Where(x => !x.Hidden && x.Bestseller)
                                              .OrderBy(x => Guid.NewGuid())
                                              .Take(3)
                                              .ToList();

            var viewModel = new HomeViewModel()
            {
                Categories = categories,
                NewCourses = newCourses,
                Bestsellers = bestsellers
            };

            return View(viewModel);
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }
    }
}