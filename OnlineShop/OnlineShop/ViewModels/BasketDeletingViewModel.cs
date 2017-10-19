using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class BasketDeletingViewModel
    {
        public decimal BasketTotalPrice { get; set; }
        public int BasketItemsAmount { get; set; }
        public int DeletedItemAmount { get; set; }
        public int DeletedItemId { get; set; }
    }
}