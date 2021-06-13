using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Paiement")]
    public partial class Paiement
    {
        public Paiement()
        {
            Sponsorises = new HashSet<Sponsorise>();
        }

        [Key]
        [Column("idPay")]
        public int IdPay { get; set; }
        [Column("datePay", TypeName = "datetime")]
        public DateTime? DatePay { get; set; }
        [Column("prixPay", TypeName = "decimal(18, 0)")]
        public decimal? PrixPay { get; set; }
        [Column("idEvnPay")]
        public int? IdEvnPay { get; set; }
        [Column("idUtlPay")]
        public int? IdUtlPay { get; set; }
        [Column("idPublPay")]
        public int? IdPublPay { get; set; }
        [Column("idPubPay")]
        public int? IdPubPay { get; set; }

        [ForeignKey(nameof(IdEvnPay))]
        [InverseProperty(nameof(Evenement.Paiements))]
        public virtual Evenement IdEvnPayNavigation { get; set; }
        [ForeignKey(nameof(IdPubPay))]
        [InverseProperty(nameof(Publicite.Paiements))]
        public virtual Publicite IdPubPayNavigation { get; set; }
        [ForeignKey(nameof(IdPublPay))]
        [InverseProperty(nameof(Publication.Paiements))]
        public virtual Publication IdPublPayNavigation { get; set; }
        [ForeignKey(nameof(IdUtlPay))]
        [InverseProperty(nameof(Utllisateur.Paiements))]
        public virtual Utllisateur IdUtlPayNavigation { get; set; }
        [InverseProperty(nameof(Sponsorise.IdPaySponsNavigation))]
        public virtual ICollection<Sponsorise> Sponsorises { get; set; }
    }
}
