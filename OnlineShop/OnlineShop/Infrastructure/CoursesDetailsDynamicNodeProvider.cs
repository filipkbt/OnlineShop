using MvcSiteMapProvider;
using OnlineShop.DAL;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure
{
    public class CoursesDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private CoursesContext database = new CoursesContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach(Course course in database.Courses)
            {
                DynamicNode nodeItem = new DynamicNode();
                nodeItem.Title = course.Name;
                nodeItem.Key = "Course_" + course.CourseId;
                nodeItem.ParentKey = "Category_" + course.CategoryId;
                nodeItem.RouteValues.Add("id", course.CourseId);
                returnValue.Add(nodeItem);
            }

            return returnValue;
        }
    }
}