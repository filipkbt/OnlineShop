using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "First name is necessary !")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second name is necessary !")]
        [StringLength(50)]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Address is necessary !")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is necessary !")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip code is necessary !")]
        [StringLength(6)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Phone number is necessary !")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Wrong phone number.")]
        public string Phone{ get; set; }

        [Required(ErrorMessage = "E-mail is necessary !")]
        [EmailAddress(ErrorMessage = "Wrong e-mail.")]
        public string Email { get; set; }

        public string Comment { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal OrderPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Completed
    }
}