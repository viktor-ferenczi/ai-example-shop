using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Enums;
using Shop.Data.Models;
using Shop.Web.DataMapper;
using Shop.Web.Models.Order;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrder _orderService;
        private readonly IFood _foodService;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrder orderService, IFood foodService, ShoppingCart shoppingCart, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _shoppingCart = shoppingCart;
            _foodService = foodService;
        }

        public IActionResult Checkout()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (!items.Any())
            {
                ModelState.AddModelError("", "Your cart is empty, add some items first");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // Rest of the code...
    }
}
