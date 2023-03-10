
namespace Gold.Models
{
    public partial class Kart
    {
        public Kart()
        {
            Products = new HashSet<Product>();
        }

      
        public int Id { get; set; }
       
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
