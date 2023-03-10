

namespace GoldAdmin.Models
{
    public partial class Product
    {

        public int Id { get; set; }
        public byte[] Pic { get; set; }
        public double? Wight { get; set; }
        public bool? IsGift { get; set; }
        public int? IdCat { get; set; }
        public int? IdKart { get; set; }
        public virtual Category IdCatNavigation { get; set; }

        public virtual Kart IdKartNavigation { get; set; }
    }
}
