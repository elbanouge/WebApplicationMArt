using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    public partial class Notification
    {
        [Key]
        [Column("idNot")]
        public int IdNot { get; set; }
        [Column("contenuNot", TypeName = "text")]
        public string ContenuNot { get; set; }
        [Column("luNot")]
        public bool? LuNot { get; set; }
        [Column("idUtlNot")]
        public int? IdUtlNot { get; set; }

        [ForeignKey(nameof(IdUtlNot))]
        [InverseProperty(nameof(Utllisateur.Notifications))]
        public virtual Utllisateur IdUtlNotNavigation { get; set; }
    }
}
