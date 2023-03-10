using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    public partial class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("pic", TypeName = "image")]
        public byte[]? Pic { get; set; }
        [Column("wight")]
        public double? Wight { get; set; }
        [Column("is_gift")]
        public bool? IsGift { get; set; }
        [Column("id_cat")]
        public int? IdCat { get; set; }
        [Column("id_kart")]
        public int? IdKart { get; set; }

        [ForeignKey("IdCat")]
        [InverseProperty("Products")]
        public virtual Category? IdCatNavigation { get; set; }
        [ForeignKey("IdKart")]
        [InverseProperty("Products")]
        public virtual Kart? IdKartNavigation { get; set; }
    }
}
