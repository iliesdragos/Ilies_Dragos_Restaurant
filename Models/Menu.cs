namespace Ilies_Dragos_Restaurant.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public ICollection<Restaurant>? Restaurants { get; set; }
        public ICollection<MenuItem>? MenuItems { get; set; }
       
    }
}
