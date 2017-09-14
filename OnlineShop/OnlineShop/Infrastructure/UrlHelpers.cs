using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Infrastructure
{
    public static class UrlHelpers
    {
        public static string CategoriesIconsPath(this UrlHelper helper, string categoryIconName)
        {
            var CategoryIconsFolder = AppConfig.CategoriesIconsFolder;
            var path = Path.Combine(CategoryIconsFolder, categoryIconName);
            var finalPath = helper.Content(path);

            return finalPath;
        }

        public static string CoursesImagesPath(this UrlHelper helper, string courseImageName)
        {
            var CoursesImagesFolder = AppConfig.CoursesImagesFolder;
            var path = Path.Combine(CoursesImagesFolder, courseImageName);
            var finalPath = helper.Content(path);

            return finalPath;
        }
    }
}