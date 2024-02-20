using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Enums;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Service
{
    public class OrderService : IOrder
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderService(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _context.Add(order);

            var orderDetails = new List<OrderDetail>(_shoppingCart.ShoppingCartItems.Count());

            foreach (var item in _shoppingCart.ShoppingCartItems)
            {
                orderDetails.Add(
                    new OrderDetail
                    {
                        OrderId = order.Id,
                        FoodId = item.Food.Id,
                        Amount = Math.Min(item.Amount, item.Food.InStock),
                        Price = item.Food.Price,
                        Food = item.Food
                    });
                _context.Update(item.Food);
                item.Food.InStock = Math.Max(item.Food.InStock - item.Amount, 0);
            }

            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();
        }

        public Order GetById(int orderId)
        {
            return GetAll()
                .FirstOrDefault(order => order.Id == orderId);
        }

        public IEnumerable<Order> GetByUserId(string userId)
        {
            return GetAll()
                .Where(order => order.User.Id == userId);
        }

        public IEnumerable<Order> GetFilteredOrders(OrderFilter filter)
        {
            var orders = string.IsNullOrEmpty(filter.UserId) ? GetAll() : GetByUserId(filter.UserId);

            if (filter.OrderBy != OrderBy.None)
            {
                SetOrderBy(orders, filter.OrderBy);
            }

            if (filter.MinimalPrice.HasValue)
            {
                orders = orders.Where(order => order.OrderTotal > filter.MinimalPrice);
            }

            if (filter.MaximalPrice.HasValue)
            {
                orders = orders.Where(order => order.OrderTotal < filter.MaximalPrice);
            }

            if (filter.MinDate.HasValue)
            {
                orders = orders.Where(order => order.OrderPlaced > filter.MinDate);
            }

            if (filter.MaxDate.HasValue)
            {
                orders = orders.Where(order => order.OrderPlaced < filter.MaxDate);
            }

            if (!string.IsNullOrEmpty(filter.ZipCode))
            {
                orders = orders.Where(order => order.ZipCode == filter.ZipCode);
            }

            return orders.Skip(filter.Offset).Take(filter.Limit);
        }

        private void SetOrderBy(IEnumerable<Order> orders, OrderBy orderBy)
        {
            switch (orderBy)
            {
                case OrderBy.DateDesc:
                    orders = orders.OrderByDescending(order => order.OrderPlaced);
                    break;
                case OrderBy.DateAsc:
                    orders = orders.OrderBy(order => order.OrderPlaced);
                    break;
                case OrderBy.PriceAsc:
                    orders = orders.OrderBy(order => order.OrderTotal);
                    break;
                case OrderBy.PriceDesc:
                    orders = orders.OrderByDescending(order => order.OrderTotal);
                    break;
                default: throw new NotImplementedException();
            }
        }

        public IEnumerable<Order> GetUserLatestOrders(int count, string userId)
        {
            return GetByUserId(userId)
                .OrderByDescending(order => order.OrderPlaced)
                .Take(count);
        }

        public IEnumerable<Food> GetUserMostPopularFoods(string userId)
        {
            Dictionary<Food, int> foods = new Dictionary<Food, int>();

            var a = GetByUserId(userId);
            foreach (var order in a)
            {
                foreach (var line in order.OrderLines)
                {
                    if (foods.ContainsKey(line.Food))
                    {
                        foods[line.Food] += line.Amount;
                    }
                    else
                    {
                        foods[line.Food] = line.Amount;
                    }
                }
            }

            return foods.OrderByDescending(keyValues => keyValues.Value).Select((keyValues) => keyValues.Key).Take(10);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                .AsNoTracking()
                .Include(order => order.User)
                .Include(order => order.OrderLines).ThenInclude(line => line.Food);
        }
    }
}