using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Course name is necessary !")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Course author is necessary !")]
        [StringLength(100)]
        public string Author { get; set; }
        public DateTime AddDate { get; set; }
        [StringLength(100)]
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }        

        public virtual Category Category { get; set; }
    }
}