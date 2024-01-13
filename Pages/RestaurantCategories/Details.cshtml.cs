using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ilies_Dragos_Restaurant.Data;
using Ilies_Dragos_Restaurant.Models;

namespace Ilies_Dragos_Restaurant.Pages.RestaurantCategories
{
    public class DetailsModel : PageModel
    {
        private readonly Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext _context;

        public DetailsModel(Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext context)
        {
            _context = context;
        }

        public RestaurantCategory RestaurantCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantcategory = await _context.RestaurantCategory.FirstOrDefaultAsync(m => m.ID == id);
            if (restaurantcategory == null)
            {
                return NotFound();
            }
            else
            {
                RestaurantCategory = restaurantcategory;
            }
            return Page();
        }
    }
}
