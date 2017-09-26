using MvcSiteMapProvider;
using OnlineShop.DAL;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure
{
    public class CategoriesDynamicNodeProvider : DynamicNodeProviderBase
    {
        private CoursesContext database = new CoursesContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Category category in database.Categories)
            {
                DynamicNode nodeItem = new DynamicNode();
                nodeItem.Title = category.Name;
                nodeItem.Key = "Category_" + category.CategoryId;
                nodeItem.RouteValues.Add("name", category.Name);
                returnValue.Add(nodeItem);
            }

            return returnValue;
        }
    }
}