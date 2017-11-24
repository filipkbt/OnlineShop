﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using static OnlineShop.App_Start.IdentityConfig;
using Microsoft.Owin.Security;
using OnlineShop.ViewModels;
using OnlineShop.Models;
using System.Data.Entity;
using OnlineShop.DAL;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private CoursesContext database = new CoursesContext();

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Manage
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialsViewModel
            {
                Message = message,
                UserDetails = user.UserDetails
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile ([Bind(Prefix = "UserDetails")]UserDetails userDetails)
        {
            if(ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserDetails = userDetails;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new {Message = message});
        }

        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("password-enter", error);
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        public ActionResult OrdersList()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            IEnumerable<Order> userOrders;

            if (isAdmin)
            {
                userOrders = database.Orders.Include("OrderItems").OrderByDescending(o => o.OrderDate).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                userOrders = database.Orders.Where(o => o.UserId == userId).Include("OrderItems").OrderByDescending(o => o.OrderDate).ToArray();
            }
            return View(userOrders);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public OrderStatus ChangeOrderStatus(Order order)
        {
            Order orderToEdit = database.Orders.Find(order.OrderId);
            orderToEdit.OrderStatus = order.OrderStatus;
            database.SaveChanges();

            return order.OrderStatus;
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