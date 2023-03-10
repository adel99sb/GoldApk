
namespace GoldAdmin.Models
{
    public partial class Company
    {
        public Company()
        {
            Categories = new HashSet<Category>();
        }


        public int Id { get; set; }

        public string Name { get; set; }
        public string Pic { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
