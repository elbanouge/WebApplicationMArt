using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Evenement")]
    public partial class Evenement
    {
        public Evenement()
        {
            Paiements = new HashSet<Paiement>();
            Reservers = new HashSet<Reserver>();
        }

        [Key]
        [Column("idEvn")]
        public int IdEvn { get; set; }
        [Column("titreEvn")]
        [StringLength(250)]
        public string TitreEvn { get; set; }
        [Column("descrEvn")]
        [StringLength(250)]
        public string DescrEvn { get; set; }
        [Column("dateEven", TypeName = "datetime")]
        public DateTime? DateEven { get; set; }
        [Column("typeEvn")]
        [StringLength(250)]
        public string TypeEvn { get; set; }
        [Column("imageEvn")]
        [MaxLength(1)]
        public byte[] ImageEvn { get; set; }
        [Column("sloganEvn")]
        [StringLength(250)]
        public string SloganEvn { get; set; }
        [Column("montantEvn", TypeName = "decimal(18, 0)")]
        public decimal? MontantEvn { get; set; }
        [Column("idUtlEven")]
        public int? IdUtlEven { get; set; }

        [ForeignKey(nameof(IdUtlEven))]
        [InverseProperty(nameof(Utllisateur.Evenements))]
        public virtual Utllisateur IdUtlEvenNavigation { get; set; }
        [InverseProperty(nameof(Paiement.IdEvnPayNavigation))]
        public virtual ICollection<Paiement> Paiements { get; set; }
        [InverseProperty(nameof(Reserver.IdEvenResNavigation))]
        public virtual ICollection<Reserver> Reservers { get; set; }
    }
}
