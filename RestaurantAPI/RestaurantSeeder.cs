using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private static IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
            new Restaurant()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFC (short for Kentucyk Fried Chicken) is an American fost food restaurant chain",
                ConctactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Nashville Hot Chicken",
                        Price = 10.30M
                    },

                    new Dish()
                    {
                        Name = "Chicken Nuggets",
                        Price = 5.30M
                    },
                },
                Address = new Address()
                {
                    City = "Kraków",
                    Street = "Długa 5",
                    PostalCode = "30-001"
                }
            },

            new Restaurant()
            {
                Name = "McDonald",
                Category = "Fast Food",
                Description = "McDonald is an American fost food restaurant chain",
                ConctactEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Hamburger",
                        Price = 4.30M
                    },

                    new Dish()
                    {
                        Name = "Chesseburger",
                        Price = 4.30M
                    },
                },
                Address = new Address()
                {
                    City = "Kraków",
                    Street = "Krótka 12",
                    PostalCode = "30-001"
                }
            }
        };
            return restaurants;

        }
    }
}
