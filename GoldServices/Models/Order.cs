using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    [Keyless]
    [Table("Order")]
    public partial class Order
    {
        [Column("id_cos")]
        public int? IdCos { get; set; }
        [Column("id_pro")]
        public int? IdPro { get; set; }
        [Column("price")]
        public double? Price { get; set; }

        [ForeignKey("IdCos")]
        public virtual Costumer? IdCosNavigation { get; set; }
        [ForeignKey("IdPro")]
        public virtual Product? IdProNavigation { get; set; }
    }
}
