using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Reserver")]
    public partial class Reserver
    {
        [Key]
        [Column("idUtlRes")]
        public int IdUtlRes { get; set; }
        [Key]
        [Column("idEvenRes")]
        public int IdEvenRes { get; set; }

        [ForeignKey(nameof(IdEvenRes))]
        [InverseProperty(nameof(Evenement.Reservers))]
        public virtual Evenement IdEvenResNavigation { get; set; }
        [ForeignKey(nameof(IdUtlRes))]
        [InverseProperty(nameof(Utllisateur.Reservers))]
        public virtual Utllisateur IdUtlResNavigation { get; set; }
    }
}
