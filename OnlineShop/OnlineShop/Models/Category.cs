using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is necessary !")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Category description is necessary !")]
        [StringLength(100)]
        public string Description { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<Course> Courses {get;set;}
    }
}