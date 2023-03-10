

namespace GoldAdmin.Models
{

    public partial class Order
    {
        public int? IdCos { get; set; }
        public int? IdPro { get; set; }
        public double? Price { get; set; }

        public virtual Costumer IdCosNavigation { get; set; }
        public virtual Product IdProNavigation { get; set; }
    }
}
