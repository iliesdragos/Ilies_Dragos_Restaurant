using System.Security.Policy;

namespace Ilies_Dragos_Restaurant.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public string Descriere { get; set; }
        public string OrarFunctionare { get; set; }
        public int? MenuID { get; set; }
        public Menu? Menu { get; set; }

        public ICollection<RestaurantCategoryAssignment>? RestaurantCategoryAssignments { get; set; }
    }
}
