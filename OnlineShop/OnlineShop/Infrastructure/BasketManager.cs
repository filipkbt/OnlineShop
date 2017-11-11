using OnlineShop.DAL;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure
{
    public class BasketManager
    {
        private CoursesContext database;
        private ISessionManager session;

        public BasketManager(ISessionManager session, CoursesContext database)
        {
            this.session = session;
            this.database = database;
        }

        public List<BasketItem> DownloadBasket()
        {
            List<BasketItem> basket;

            if (session.Get<List<BasketItem>>(Consts.basketSessionKey) == null)
            {
                basket = new List<BasketItem>();
            }
            else
            {
                basket = session.Get<List<BasketItem>>(Consts.basketSessionKey) as List<BasketItem>;
            }

            return basket;
        }

        public void AddToBasket(int courseId)
        {
            var basket = DownloadBasket();
            var basketItem = basket.Find(x => x.Course.CourseId == courseId);

            if (basketItem != null)
            {
                basketItem.Amount++;
            }
            else
            {
                var courseToAdd = database.Courses.Where(x => x.CourseId == courseId).SingleOrDefault();

                if (courseToAdd != null)
                {
                    var newBasketItem = new BasketItem()
                    {
                        Course = courseToAdd,
                        Amount = 1,
                        Value = courseToAdd.Price
                    };
                    basket.Add(newBasketItem);
                }
            }
            session.Set(Consts.basketSessionKey, basket);
        }

        public int DeleteFromBasket(int courseId)
        {
            var basket = DownloadBasket();
            var basketItem = basket.Find(x => x.Course.CourseId == courseId);

            if (basketItem != null)
            {
                if (basketItem.Amount > 1)
                {
                    basketItem.Amount--;
                    return basketItem.Amount;
                }
                else
                {
                    basket.Remove(basketItem);
                }
            }
            return 0;
        }

        public decimal DownloadBasketValue()
        {
            var basket = DownloadBasket();
            return basket.Sum(x => (x.Amount * x.Course.Price));
        }

        public int DownloadBasketAmount()
        {
            var basket = DownloadBasket();
            int amount = basket.Sum(x => x.Amount);
            return amount;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var basket = DownloadBasket();
            newOrder.OrderDate = DateTime.Now;
            newOrder.UserId = userId;

            database.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
            {
                newOrder.OrderItems = new List<OrderItem>();
            }
            decimal basketValue = 0;

            foreach (var basketItem in basket)
            {
                var newBasketItem = new OrderItem()
                {
                    CourseId = basketItem.Course.CourseId,
                    Quantity = basketItem.Amount,
                    ItemPrice = basketItem.Course.Price
                };
                basketValue += (basketItem.Amount * basketItem.Course.Price);
                newOrder.OrderItems.Add(newBasketItem);
            }
            newOrder.OrderPrice = basketValue;
            database.SaveChanges();

            return newOrder;
        }

        public void SetEmptyBasket()
        {
            session.Set<List<BasketItem>>(Consts.basketSessionKey, null);
        }
    }
}