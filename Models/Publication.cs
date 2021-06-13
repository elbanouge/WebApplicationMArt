using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Publication")]
    public partial class Publication
    {
        public Publication()
        {
            Media = new HashSet<Medium>();
            Paiements = new HashSet<Paiement>();
            Reagirs = new HashSet<Reagir>();
            Sponsorises = new HashSet<Sponsorise>();
        }

        [Key]
        [Column("idP")]
        public int IdP { get; set; }
        [Column("dateP", TypeName = "datetime")]
        public DateTime? DateP { get; set; }
        [Column("titreP")]
        [StringLength(250)]
        public string TitreP { get; set; }
        [Column("textCnt", TypeName = "text")]
        public string TextCnt { get; set; }
        [Column("idUtlPubl")]
        public int? IdUtlPubl { get; set; }
        [Column("idGenrePubl")]
        public int? IdGenrePubl { get; set; }

        [ForeignKey(nameof(IdGenrePubl))]
        [InverseProperty(nameof(Genre.Publications))]
        public virtual Genre IdGenrePublNavigation { get; set; }
        [ForeignKey(nameof(IdUtlPubl))]
        [InverseProperty(nameof(Utllisateur.Publications))]
        public virtual Utllisateur IdUtlPublNavigation { get; set; }
        [InverseProperty(nameof(Medium.IdPublMedNavigation))]
        public virtual ICollection<Medium> Media { get; set; }
        [InverseProperty(nameof(Paiement.IdPublPayNavigation))]
        public virtual ICollection<Paiement> Paiements { get; set; }
        [InverseProperty(nameof(Reagir.IdPublReaNavigation))]
        public virtual ICollection<Reagir> Reagirs { get; set; }
        [InverseProperty(nameof(Sponsorise.IdPublSponsNavigation))]
        public virtual ICollection<Sponsorise> Sponsorises { get; set; }
    }
}
