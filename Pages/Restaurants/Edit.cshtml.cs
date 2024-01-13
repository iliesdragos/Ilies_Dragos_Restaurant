using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ilies_Dragos_Restaurant.Data;
using Ilies_Dragos_Restaurant.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ilies_Dragos_Restaurant.Pages.Restaurants
{
    [Authorize(Roles = "Admin")]
    public class EditModel : RestaurantCategoriesPageModel
    {
        private readonly Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext _context;

        public EditModel(Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null  || _context.Restaurant == null)
            {
                return NotFound();
            }

            Restaurant =  await _context.Restaurant
                .Include(b => b.Menu)
                .Include(b => b.RestaurantCategoryAssignments).ThenInclude(b => b.RestaurantCategory)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            var restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Restaurant);
            Restaurant = restaurant;
            ViewData["MenuID"] = new SelectList(_context.Set<Menu>(), "ID", "MenuName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantToUpdate = await _context.Restaurant
                .Include(b => b.Menu)
                .Include(r => r.RestaurantCategoryAssignments)
                    .ThenInclude(r => r.RestaurantCategory)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (restaurantToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Restaurant>(
                restaurantToUpdate,
                "Restaurant",
                r => r.Nume, r => r.Adresa, r => r.Descriere, r => r.OrarFunctionare, r => r.MenuID))
            {
                // Actualizarea categoriilor înainte de a salva modificările
                UpdateRestaurantCategories(_context, selectedCategories, restaurantToUpdate);

                // Salvează modificările
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            UpdateRestaurantCategories(_context, selectedCategories, restaurantToUpdate);
            // Re-popularea datelor dacă există o eroare
            PopulateAssignedCategoryData(_context, restaurantToUpdate);
            return Page();
        }

    }
}
