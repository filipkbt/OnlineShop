using OnlineShop.DAL;
using OnlineShop.Infrastructure;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class BasketController : Controller
    {
        private BasketManager basketManager;
        private ISessionManager sessionManager { get; set; }
        private CoursesContext database;

        public BasketController()
        {
            database = new CoursesContext();
            sessionManager = new SessionManager();
            basketManager = new BasketManager(sessionManager, database);
        }
        // GET: Basket
        public ActionResult Index()
        {
            var basketItems = basketManager.DownloadBasket();
            var totalPrice = basketManager.DownloadBasketValue();
            BasketViewModel basketViewModel = new BasketViewModel()
            {
                BasketItems = basketItems,
                TotalPrice = totalPrice
            };

            return View(basketViewModel);
        }

        public ActionResult AddToBasket(int id)
        {
            basketManager.AddToBasket(id);
            return RedirectToAction("Index");
        }

        public int GetBasketItemsAmount()
        {
            return basketManager.DownloadBasketAmount();
        }

        public ActionResult DeleteFromBasket(int courseId)
        {
            int deletedItemAmount = basketManager.DeleteFromBasket(courseId);
            int basketItemsAmount = basketManager.DownloadBasketAmount();
            decimal basketValue = basketManager.DownloadBasketValue();

            var result = new BasketDeletingViewModel()
            {
                DeletedItemId = courseId,
                DeletedItemAmount = deletedItemAmount,
                BasketTotalPrice = basketValue,
                BasketItemsAmount = basketItemsAmount,
            };
            return Json(result);
        }
    }
}