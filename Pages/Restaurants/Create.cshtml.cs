using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ilies_Dragos_Restaurant.Data;
using Ilies_Dragos_Restaurant.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace Ilies_Dragos_Restaurant.Pages.Restaurants
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : RestaurantCategoriesPageModel
    {
        private readonly Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext _context;

        public CreateModel(Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MenuID"] = new SelectList(_context.Set<Menu>(), "ID", "MenuName");
            var restaurant = new Restaurant();
            restaurant.RestaurantCategoryAssignments = new List<RestaurantCategoryAssignment>();
            PopulateAssignedCategoryData(_context, restaurant);
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRestaurant = new Restaurant();

            if (selectedCategories != null)
            {
                newRestaurant.RestaurantCategoryAssignments = new List<RestaurantCategoryAssignment>();
                foreach (var cat in selectedCategories)
                {
                    var categoryToAdd = new RestaurantCategoryAssignment
                    {
                        RestaurantCategoryID = int.Parse(cat)
                    };
                    newRestaurant.RestaurantCategoryAssignments.Add(categoryToAdd);
                }
            }

            Restaurant.RestaurantCategoryAssignments = newRestaurant.RestaurantCategoryAssignments;

            _context.Restaurant.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
