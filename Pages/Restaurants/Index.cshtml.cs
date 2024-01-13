using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ilies_Dragos_Restaurant.Data;
using Ilies_Dragos_Restaurant.Models;

namespace Ilies_Dragos_Restaurant.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext _context;

        public IndexModel(Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; } = default!;
        public RestaurantData RestaurantD { get; set; }
        public int? RestaurantID { get; set; }
        public int? CategoryID { get; set; }
        public string NameSort { get; set; }
        public string CategorySort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            RestaurantD = new RestaurantData();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CategorySort = sortOrder == "category" ? "category_desc" : "category";
            CurrentFilter = searchString;

            RestaurantD.Restaurants = await _context.Restaurant
                .Include(r => r.Menu)
                .Include(r => r.RestaurantCategoryAssignments)
                    .ThenInclude(r => r.RestaurantCategory)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();

           
            if (!String.IsNullOrEmpty(searchString))
            {
                RestaurantD.Restaurants = RestaurantD.Restaurants.Where(s => s.Nume.Contains(searchString)
                                             || s.RestaurantCategoryAssignments.Any(c => c.RestaurantCategory.CategoryName.Contains(searchString)));
            }

            if (id != null)
            {
                RestaurantID = id.Value;
                Restaurant restaurant = RestaurantD.Restaurants
                    .Where(i => i.ID == id.Value).Single();
                if (restaurant != null)
                {
                    RestaurantD.RestaurantCategories = restaurant.RestaurantCategoryAssignments
                        .Select(rc => rc.RestaurantCategory);
                }
            }
            switch (sortOrder)
            {
                case "name_desc":
                    RestaurantD.Restaurants = RestaurantD.Restaurants.OrderByDescending(r => r.Nume);
                    break;
                case "category_desc":
                    RestaurantD.Restaurants = RestaurantD.Restaurants
                                              .OrderByDescending(r => r.RestaurantCategoryAssignments
                                              .Select(c => c.RestaurantCategory.CategoryName)
                                              .FirstOrDefault()); // presupunând că fiecare restaurant are cel puțin o categorie
                    break;
                case "category":
                    RestaurantD.Restaurants = RestaurantD.Restaurants
                                              .OrderBy(r => r.RestaurantCategoryAssignments
                                              .Select(c => c.RestaurantCategory.CategoryName)
                                              .FirstOrDefault()); // și aici
                    break;
                default:
                    RestaurantD.Restaurants = RestaurantD.Restaurants.OrderBy(r => r.Nume);
                    break;
            }
           

        }
    }
}
