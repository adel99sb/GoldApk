using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    public partial class Message
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("form_num")]
        [StringLength(50)]
        public string? FormNum { get; set; }
        [Column("to_nom")]
        [StringLength(50)]
        public string? ToNom { get; set; }
        [Column("id_cos")]
        public int? IdCos { get; set; }

        [ForeignKey("IdCos")]
        [InverseProperty("Messages")]
        public virtual Costumer? IdCosNavigation { get; set; }
    }
}
