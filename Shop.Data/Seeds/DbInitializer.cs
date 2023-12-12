using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Seeds
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                }

                // Call the Categories property to initialize the dictionary
                var categories = Categories;

                if (!context.Foods.Any())
                {
                    var foods = new Food[]
                    {
                         new Food
                         {
                             Name = "Eggplant",
                             Category = categories["Vegetable"],
                             ImageUrl = "https://images.pexels.com/photos/321551/pexels-photo-321551.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=450&w=450",
                             InStock = 20,
                             IsPreferedFood = false,
                             ShortDescription = "The aubergine (also called eggplant) is a plant. Its fruit is eaten as a vegetable.",
                             LongDescription = "The plant is in the nightshade family of plants. It is related to the potato and tomato. Originally it comes from India and Sri Lanka. The Latin/French term aubergine originally derives from the historical city of Vergina (Βεργίνα) in Greece.",
                             Price = 4.5M
                         },
                        //... rest of the foods
                        new Food
                        {
                            Name = "Tomato",
                            Category = categories["Vegetable"],
                            ImageUrl = "https://images.pexels.com/photos/321551/pexels-photo-321551.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=450&w=450",
                            InStock = 20,
                            IsPreferedFood = false,
                            ShortDescription = "The tomato is a plant. Its fruit is eaten as a vegetable.",
                            LongDescription = "The plant is in the nightshade family of plants. It is related to the potato and tomato. Originally it comes from India and Sri Lanka. The Latin/French term aubergine originally derives from the historical city of Vergina (Βεργίνα) in Greece.",
                            Price = 4.5M
                        },
                        //... rest of the foods
                    };

                    context.AddRange(foods);
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category
                        {
                            Name = "Vegetable",
                            Description = "All vegetables and legumes/beans foods",
                            ImageUrl = "https://images.pexels.com/photos/533360/pexels-photo-533360.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=450&w=450",
                        },
                    //... rest of the categories
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.Name, genre);
                    }
                }

                return categories;
            }
        }
    }
}
