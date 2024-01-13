using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ilies_Dragos_Restaurant.Models;

namespace Ilies_Dragos_Restaurant.Data
{
    public class Ilies_Dragos_RestaurantContext : DbContext
    {
        public Ilies_Dragos_RestaurantContext (DbContextOptions<Ilies_Dragos_RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Ilies_Dragos_Restaurant.Models.Restaurant> Restaurant { get; set; } = default!;
        public DbSet<Ilies_Dragos_Restaurant.Models.Menu>? Menu { get; set; } = default!;
        public DbSet<Ilies_Dragos_Restaurant.Models.MenuItem>? MenuItem { get; set; } = default!;
        public DbSet<Ilies_Dragos_Restaurant.Models.RestaurantCategory>? RestaurantCategory { get; set; }
        public DbSet<Ilies_Dragos_Restaurant.Models.Member> Member { get; set; } = default!;

    }
}
