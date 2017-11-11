using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnlineShop.DAL;
using OnlineShop.Infrastructure;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static OnlineShop.App_Start.IdentityConfig;

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

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    FirstName = user.UserDetails.FirstName,
                    SecondName = user.UserDetails.SecondName,
                    Address = user.UserDetails.Address,
                    City = user.UserDetails.City,
                    ZipCode = user.UserDetails.ZipCode,
                    Email = user.UserDetails.Email,
                    Phone = user.UserDetails.Phone
                };
                return View(order);
            }
            else
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Pay", "Basket") });
        }

        [HttpPost]
        public async Task<ActionResult> Pay(Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newOrder = basketManager.CreateOrder(orderDetails, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserDetails);
                await UserManager.UpdateAsync(user);

                basketManager.SetEmptyBasket();

                return RedirectToAction("OrderConfirmation");
            }
            else
                return View(orderDetails);
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}