using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class BasketItem
    {
        public Course Course { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}