namespace OnlineShop.Migrations
{
    using DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<OnlineShop.DAL.CoursesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineShop.DAL.CoursesContext";
        }

        protected override void Seed(OnlineShop.DAL.CoursesContext context)
        {
            CoursesInitializer.SeedCoursesData(context);
        }
    }
}
