using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Reagir")]
    public partial class Reagir
    {
        [Key]
        [Column("idPublRea")]
        public int IdPublRea { get; set; }
        [Key]
        [Column("idUtlRea")]
        public int IdUtlRea { get; set; }
        public bool? JaimeRea { get; set; }
        [Column("commentaire", TypeName = "text")]
        public string Commentaire { get; set; }

        [ForeignKey(nameof(IdPublRea))]
        [InverseProperty(nameof(Publication.Reagirs))]
        public virtual Publication IdPublReaNavigation { get; set; }
        [ForeignKey(nameof(IdUtlRea))]
        [InverseProperty(nameof(Utllisateur.Reagirs))]
        public virtual Utllisateur IdUtlReaNavigation { get; set; }
    }
}
