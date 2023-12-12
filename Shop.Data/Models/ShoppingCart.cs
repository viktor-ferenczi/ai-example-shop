using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Data.Models
{
	public class ShoppingCart
	{
		private readonly ApplicationDbContext _context;

		public ShoppingCart(ApplicationDbContext context)
		{
			_context = context;
		}

		public string Id { get; set; }
		public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

		public static ShoppingCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<ApplicationDbContext>();
			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", cartId);
			return new ShoppingCart(context) { Id = cartId };
		}

		public bool AddToCart(Food food, int amount)
		{
			if(food.InStock == 0 || amount == 0)
			{
				return false;
			}
			
			var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
				s => s.Food.Id == food.Id && s.ShoppingCartId == Id);
            var isValidAmount = true;
			if (shoppingCartItem == null)
			{
                isValidAmount = AddNewItem(food, amount);
			}
			else
			{
                isValidAmount = AddExistingItem(shoppingCartItem, food, amount);
            }

			_context.SaveChanges();
            return isValidAmount;
		}

		private bool AddNewItem(Food food, int amount)
		{
			var isValidAmount = true;
			if (amount > food.InStock)
			{
				isValidAmount = false;
			}
			var shoppingCartItem = new ShoppingCartItem
			{
				ShoppingCartId = Id, // Initialize ShoppingCartId
				Food = food, // Initialize Food
				Amount = Math.Min(food.InStock, amount)
			};
			_context.ShoppingCartItems.Add(shoppingCartItem);
			return isValidAmount;
		}

		private bool AddExistingItem(ShoppingCartItem shoppingCartItem, Food food, int amount)
		{
			var isValidAmount = true;
			if(food.InStock - shoppingCartItem.Amount - amount >= 0)
			{
				shoppingCartItem.Amount +=  amount;
			}
			else
			{
				shoppingCartItem.Amount += (food.InStock - shoppingCartItem.Amount);
				isValidAmount = false;
			}
			return isValidAmount;
		}

		public int RemoveFromCart(Food food)
		{
			var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
				s => s.Food.Id == food.Id && s.ShoppingCartId == Id);
			int localAmount = 0;
			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
					localAmount = shoppingCartItem.Amount;
				}
				else
				{
					_context.ShoppingCartItems.Remove(shoppingCartItem);
				}
			}

			_context.SaveChanges();
			return localAmount;
		}

		public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
		{
			return ShoppingCartItems ??
				   (ShoppingCartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
					   .Include(s => s.Food));
		}

		public void ClearCart()
		{
			var cartItems = _context
				.ShoppingCartItems
				.Where(cart => cart.ShoppingCartId == Id);

			_context.ShoppingCartItems.RemoveRange(cartItems);
			_context.SaveChanges();
		}

		public decimal GetShoppingCartTotal()
		{
			return _context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
				.Select(c => c.Food.Price * c.Amount).Sum();
		}

	}
}
