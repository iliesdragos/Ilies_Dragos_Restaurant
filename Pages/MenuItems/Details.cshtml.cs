using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ilies_Dragos_Restaurant.Data;
using Ilies_Dragos_Restaurant.Models;

namespace Ilies_Dragos_Restaurant.Pages.MenuItems
{
    public class DetailsModel : PageModel
    {
        private readonly Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext _context;

        public DetailsModel(Ilies_Dragos_Restaurant.Data.Ilies_Dragos_RestaurantContext context)
        {
            _context = context;
        }

        public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItem.FirstOrDefaultAsync(m => m.ID == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            else
            {
                MenuItem = menuitem;
            }
            return Page();
        }
    }
}
