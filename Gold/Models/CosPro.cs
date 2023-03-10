
namespace Gold.Models
{
    public partial class CosPro
    {
        public int? IdCos { get; set; }
        public int? IdPro { get; set; }
        public double? Like { get; set; }
        public double? Unlike { get; set; }
        public double? Size { get; set; }
        public double? Workmanshipe { get; set; }

        public virtual Costumer IdCosNavigation { get; set; }
        public virtual Product IdProNavigation { get; set; }
    }
}
