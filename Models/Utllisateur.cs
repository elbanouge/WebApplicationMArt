using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Utllisateur")]
    public partial class Utllisateur
    {
        public Utllisateur()
        {
            Evenements = new HashSet<Evenement>();
            Notifications = new HashSet<Notification>();
            Paiements = new HashSet<Paiement>();
            Publications = new HashSet<Publication>();
            Reagirs = new HashSet<Reagir>();
            Reservers = new HashSet<Reserver>();
            SuivreIdUtlFsuivreNavigations = new HashSet<Suivre>();
            SuivreIdUtlSuivreNavigations = new HashSet<Suivre>();
        }

        [Key]
        [Column("idUtl")]
        public int IdUtl { get; set; }
        [Column("nomUtl")]
        [StringLength(250)]
        public string NomUtl { get; set; }
        [Column("prenomUtl")]
        [StringLength(250)]
        public string PrenomUtl { get; set; }
        [Column("motPassUtl")]
        [StringLength(250)]
        public string MotPassUtl { get; set; }
        [Column("telUtl")]
        [StringLength(250)]
        public string TelUtl { get; set; }
        [Column("emailUtl")]
        [StringLength(250)]
        public string EmailUtl { get; set; }
        [Column("adresseUtl")]
        [StringLength(250)]
        public string AdresseUtl { get; set; }
        [Column("paysUtl")]
        [StringLength(250)]
        public string PaysUtl { get; set; }
        [Column("domaineUtl")]
        [StringLength(250)]
        public string DomaineUtl { get; set; }
        [Column("imageUtl")]
        [MaxLength(1)]
        public byte[] ImageUtl { get; set; }

        [InverseProperty(nameof(Evenement.IdUtlEvenNavigation))]
        public virtual ICollection<Evenement> Evenements { get; set; }
        [InverseProperty(nameof(Notification.IdUtlNotNavigation))]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty(nameof(Paiement.IdUtlPayNavigation))]
        public virtual ICollection<Paiement> Paiements { get; set; }
        [InverseProperty(nameof(Publication.IdUtlPublNavigation))]
        public virtual ICollection<Publication> Publications { get; set; }
        [InverseProperty(nameof(Reagir.IdUtlReaNavigation))]
        public virtual ICollection<Reagir> Reagirs { get; set; }
        [InverseProperty(nameof(Reserver.IdUtlResNavigation))]
        public virtual ICollection<Reserver> Reservers { get; set; }
        [InverseProperty(nameof(Suivre.IdUtlFsuivreNavigation))]
        public virtual ICollection<Suivre> SuivreIdUtlFsuivreNavigations { get; set; }
        [InverseProperty(nameof(Suivre.IdUtlSuivreNavigation))]
        public virtual ICollection<Suivre> SuivreIdUtlSuivreNavigations { get; set; }
    }
}
