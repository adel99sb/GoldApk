using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    [Table("Kart")]
    public partial class Kart
    {
        public Kart()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("price")]
        public double? Price { get; set; }

        [InverseProperty("IdKartNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
