using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldServices.Models
{
    public partial class Costumer
    {
        public Costumer()
        {
            Messages = new HashSet<Message>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string? Password { get; set; }
        [Column("phone")]
        [StringLength(50)]
        public string? Phone { get; set; }
        [Column("e-mail")]
        [StringLength(50)]
        public string? EMail { get; set; }
        [Column("verfacation_code")]
        [StringLength(50)]
        public string? VerfacationCode { get; set; }

        [InverseProperty("IdCosNavigation")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
