using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure
{
    public class AppConfig
    {
        private static string _categoriesIconsFolder = ConfigurationManager.AppSettings["CategoriesIconsFolder"];

        public static string CategoriesIconsFolder
        {
            get
            {
                return _categoriesIconsFolder;
            }
        }

        private static string _coursesImagesFolder = ConfigurationManager.AppSettings["CoursesImagesFolder"];

        public static string CoursesImagesFolder
        {
            get
            {
                return _coursesImagesFolder;
            }
        }
    }
}