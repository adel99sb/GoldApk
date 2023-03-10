using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    [Keyless]
    [Table("Cos_Pro")]
    public partial class CosPro
    {
        [Column("id_cos")]
        public int? IdCos { get; set; }
        [Column("id_pro")]
        public int? IdPro { get; set; }
        [Column("like")]
        public double? Like { get; set; }
        [Column("unlike")]
        public double? Unlike { get; set; }
        [Column("size")]
        public double? Size { get; set; }
        [Column("workmanshipe")]
        public double? Workmanshipe { get; set; }

        [ForeignKey("IdCos")]
        public virtual Costumer? IdCosNavigation { get; set; }
        [ForeignKey("IdPro")]
        public virtual Product? IdProNavigation { get; set; }
    }
}
