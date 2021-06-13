using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Suivre")]
    public partial class Suivre
    {
        [Key]
        [Column("idUtlSuivre")]
        public int IdUtlSuivre { get; set; }
        [Key]
        [Column("idUtlFSuivre")]
        public int IdUtlFsuivre { get; set; }

        [ForeignKey(nameof(IdUtlFsuivre))]
        [InverseProperty(nameof(Utllisateur.SuivreIdUtlFsuivreNavigations))]
        public virtual Utllisateur IdUtlFsuivreNavigation { get; set; }
        [ForeignKey(nameof(IdUtlSuivre))]
        [InverseProperty(nameof(Utllisateur.SuivreIdUtlSuivreNavigations))]
        public virtual Utllisateur IdUtlSuivreNavigation { get; set; }
    }
}
