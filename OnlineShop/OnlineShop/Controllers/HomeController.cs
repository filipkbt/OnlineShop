using OnlineShop.DAL;
using OnlineShop.Models;
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
            var categoriesList = database.Categories.ToList();

            return View();
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }
    }
}