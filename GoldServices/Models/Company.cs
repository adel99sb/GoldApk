using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    public partial class Company
    {
        public Company()
        {
            Categories = new HashSet<Category>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("pic")]
        public string? Pic { get; set; }

        [InverseProperty("IdComNavigation")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
