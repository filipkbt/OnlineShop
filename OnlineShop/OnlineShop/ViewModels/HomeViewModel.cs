using OnlineShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Course> NewCourses { get; set; }
        public IEnumerable<Course> Bestsellers { get; set; }
    }
}