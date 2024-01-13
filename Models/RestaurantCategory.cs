namespace Ilies_Dragos_Restaurant.Models
{
    public class RestaurantCategory
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<RestaurantCategoryAssignment>? RestaurantCategoryAssignments { get; set; }

         
    }
}
