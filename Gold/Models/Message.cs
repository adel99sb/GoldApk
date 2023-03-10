
namespace Gold.Models
{
    public partial class Message
    {
        public int Id { get; set; }

        public string FormNum { get; set; }

        public string ToNom { get; set; }
        public int IdCos { get; set; }

        public virtual Costumer IdCosNavigation { get; set; }
    }
}
