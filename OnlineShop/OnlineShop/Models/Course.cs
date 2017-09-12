using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime AddDate { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }

        public virtual Category Category { get; set; }
    }
}