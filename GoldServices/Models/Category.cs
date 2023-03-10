using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    [Table("categories")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("id_com")]
        public int? IdCom { get; set; }

        [ForeignKey("IdCom")]
        [InverseProperty("Categories")]
        public virtual Company? IdComNavigation { get; set; }
        [InverseProperty("IdCatNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
