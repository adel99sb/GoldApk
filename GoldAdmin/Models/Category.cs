

namespace GoldAdmin.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

       
        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdCom { get; set; }
        public virtual Company IdComNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
