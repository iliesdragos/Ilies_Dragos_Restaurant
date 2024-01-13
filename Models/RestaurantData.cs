namespace Ilies_Dragos_Restaurant.Models
{
    public class RestaurantData
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<RestaurantCategory> RestaurantCategories { get; set; }
        public IEnumerable<RestaurantCategoryAssignment> RestaurantCategoryAssignments { get; set; }
    }
}
