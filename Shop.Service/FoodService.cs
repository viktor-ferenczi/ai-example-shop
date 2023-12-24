using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Shop.Service
{
    public class FoodService : IFood
    {
        private readonly ApplicationDbContext _context;

        //TODO consider using use-case specific repositories instead of exposing the entire dbcontext
        public FoodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteFood(int id)
        {
            var food = GetById(id);
            if (food == null)
            {
                throw new ArgumentException($"Food with ID {id} does not exist.");
            }
            _context.Remove(food);
            _context.SaveChanges();
        }

        public void EditFood(Food food)
        {
            var model = _context.Foods.First(f => f.Id == food.Id);
            _context.Entry<Food>(model).State = EntityState.Detached;
            _context.Update(food);
            _context.SaveChanges();
        }
        public IEnumerable<Food> GetAll()
        {
            return _context.Foods
                .Include(food => food.Category);
        }

        public Food GetById(int id)
        {
            return GetAll().FirstOrDefault(food => food.Id == id);
        }

        public IEnumerable<Food> GetFilteredFoods(int categoryId, string searchQuery)
        {

            if (string.IsNullOrEmpty(searchQuery) || string.IsNullOrWhiteSpace(searchQuery))
            {
                return GetFoodsByCategoryId(categoryId);
            }

            return GetFilteredFoods(searchQuery).Where(food => food.Category.Id == categoryId);
        }

        //TODO ambiguous method parameter naming
        public IEnumerable<Food> GetFilteredFoods(string searchQuery)
        {
            const int MAX_QUERY_LENGTH = 10;
            var queries = string.IsNullOrEmpty(searchQuery) ? null : Regex.Replace(searchQuery, @"\s+", " ").Trim().ToLower().Split(" ");
            if (queries == null)
            {
                //TODO magic number
                return GetPreferred(MAX_QUERY_LENGTH);
            }

            return GetAll().Where(item => queries.Any(query => (item.Name.ToLower().Contains(query))));
        }

        public IEnumerable<Food> GetFoodsByCategoryId(int categoryId)
        {
            return GetAll().Where(food => food.Category.Id == categoryId);
        }

        public IEnumerable<Food> GetPreferred(int count)
        {
            return GetAll().OrderByDescending(food => food.Id).Where(food => food.IsPreferedFood && food.InStock != 0).Take(count);
        }

        public void NewFood(Food food)
        {
            _context.Add(food);
            _context.SaveChanges();
        }
    }
}
