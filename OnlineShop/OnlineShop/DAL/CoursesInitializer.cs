using OnlineShop.Migrations;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace OnlineShop.DAL
{
    public class CoursesInitializer : MigrateDatabaseToLatestVersion<CoursesContext, Configuration>
    {
        
        public static void SeedCoursesData(CoursesContext context)
        {
            var categories = new List<Category>
            {
                new Category() {CategoryId = 1, Name = "ASP.NET", ImageName="aspnet.png", Description="ASP.NET MVC Description" },
                new Category() {CategoryId = 2, Name = "JavaScript", ImageName="javascript.png", Description="JavaScript Description" },
                new Category() {CategoryId = 3, Name = "jQuery", ImageName="jquery.png", Description="jQuery Description" },
                new Category() {CategoryId = 4, Name = "HTML", ImageName="html.png", Description="HTML Description" },
                new Category() {CategoryId = 5, Name = "CSS", ImageName="css.png", Description="CSS Description" },
                new Category() {CategoryId = 6, Name = "XML", ImageName="xml.png", Description="XML Description" },
                new Category() {CategoryId = 7, Name = "C#", ImageName="csharp.png", Description="C# Description" },
            };

            categories.ForEach(category => context.Categories.AddOrUpdate(category));
            context.SaveChanges();

            var courses = new List<Course>
            {
                 new Course() { CourseId=1, Author="Filip", Name="Asp.Net", CategoryId=1, Price=0, Bestseller=true, ImageName="obrazekaspnet.png",
                AddDate = DateTime.Now, Description="ASP.NET - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=2, Author="Filip", Name="Asp.Net Mvc", CategoryId=1, Price=0, Bestseller=true, ImageName="obrazekmvc.png",
                AddDate = DateTime.Now, Description="ASP.NET MVC - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=3, Author="Filip", Name="Asp.Net Mvc - Sklep Internetowy", CategoryId=1, Price=100, Bestseller=true, ImageName="obrazekmvc2.png",
                AddDate = DateTime.Now, Description="ASP.NET MVC Course - Online shop - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=4, Author="Filip", Name="JavaScript", CategoryId=2, Price=70, Bestseller=false, ImageName="obrazekjavascript.png",
                AddDate = DateTime.Now, Description="JavaScript Course - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=5, Author="Filip", Name="jQuery", CategoryId=3, Price=90, Bestseller=true, ImageName="obrazekjquery.png",
                AddDate = DateTime.Now, Description="jQuery Course - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=6, Author="Filip", Name="Html5", CategoryId=4, Price=70, Bestseller=false, ImageName="obrazekhtml.png",
                AddDate = DateTime.Now, Description="HTML5 Course - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=7, Author="Filip", Name="Css3", CategoryId=5, Price=70, Bestseller=false, ImageName="obrazekcss.png",
                AddDate = DateTime.Now, Description="CSS3 Course - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=8, Author="Filip", Name="Xml", CategoryId=6, Price=60, Bestseller=false, ImageName="obrazekxml.png",
                AddDate = DateTime.Now, Description="XML Course - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Course() { CourseId=9, Author="Filip", Name="C#", CategoryId=7, Price=90, Bestseller=true, ImageName="obrazekcsharp.png",
                AddDate = DateTime.Now, Description="C# Course - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."}
            };

          
            courses.ForEach(course => context.Courses.AddOrUpdate(course));
            context.SaveChanges();
        }


    }
}