using System.Collections;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<Course> Courses {get;set;}
    }
}