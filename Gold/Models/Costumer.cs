
namespace Gold.Models
{
    public partial class Costumer
    {
        public Costumer()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }

        public string VerfacationCode { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
