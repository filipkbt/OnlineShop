using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderPrice { get; set; }

        List<OrderItem> OrderItems { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Completed
    }
}