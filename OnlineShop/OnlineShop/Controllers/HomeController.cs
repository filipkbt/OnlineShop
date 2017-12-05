using MvcSiteMapProvider.Caching;
using NLog;
using OnlineShop.DAL;
using OnlineShop.Infrastructure;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Home
        public ActionResult Index()
        {
            logger.Info("test");
            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> categories;

            if (cache.IsSet(Consts.categoriesCacheKey))
            {
                categories = cache.Get(Consts.categoriesCacheKey) as List<Category>;
            }
            else
            {
                categories = database.Categories.ToList();
                cache.Set(Consts.categoriesCacheKey, categories, 60);
            }

            List<Course> newCourses;

            if (cache.IsSet(Consts.newCoursesCacheKey))
            {
                newCourses = cache.Get(Consts.newCoursesCacheKey) as List<Course>;
            }
            else
            {
                newCourses = database.Courses.Where(x => !x.Hidden)
                                             .OrderByDescending(x => x.AddDate)
                                             .Take(3)
                                             .ToList();
                cache.Set(Consts.newCoursesCacheKey, newCourses, 60);
            }

            List<Course> bestsellers;

            if (cache.IsSet(Consts.bestsellersCacheKey))
            {
                bestsellers = cache.Get(Consts.bestsellersCacheKey) as List<Course>;
            }
            else
            {
                bestsellers = database.Courses.Where(x => !x.Hidden && x.Bestseller)
                                              .OrderBy(x => Guid.NewGuid())
                                              .Take(3)
                                              .ToList();
                cache.Set(Consts.bestsellersCacheKey, bestsellers, 60);
            }            

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