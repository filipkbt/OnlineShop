using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}