using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineShop.DAL
{
    public class CoursesContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public CoursesContext() : base("CoursesContext")
        {

        }

        static CoursesContext()
        {
            Database.SetInitializer<CoursesContext>(new CoursesInitializer());
        }

        public static CoursesContext Create()
        {
            return new CoursesContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}