namespace Ilies_Dragos_Restaurant.Models
{
    public class RestaurantCategoryAssignment
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }

        public int RestaurantCategoryID { get; set; }
        public RestaurantCategory RestaurantCategory { get; set; }
    }
}
