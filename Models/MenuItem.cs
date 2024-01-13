namespace Ilies_Dragos_Restaurant.Models
{
    public class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; } // Numele preparatului
        public string Description { get; set; } // Descriere opțională
        public decimal Price { get; set; } // Prețul preparatului
        public int? MenuID { get; set; }
        public Menu? Menu { get; set; }
    }
}
