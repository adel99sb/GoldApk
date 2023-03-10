
namespace Gold.Models
{
    public partial class Company
    {
        public Company()
        {
            Categories = new HashSet<Category>();
        }


        public int Id { get; set; }

        public string Name { get; set; }
        public byte[] Pic { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
