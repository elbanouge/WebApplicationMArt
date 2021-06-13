using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Sponsorise")]
    public partial class Sponsorise
    {
        [Key]
        [Column("idPublSpons")]
        public int IdPublSpons { get; set; }
        [Key]
        [Column("idPaySpons")]
        public int IdPaySpons { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateDebutSpons { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateFinSpons { get; set; }

        [ForeignKey(nameof(IdPaySpons))]
        [InverseProperty(nameof(Paiement.Sponsorises))]
        public virtual Paiement IdPaySponsNavigation { get; set; }
        [ForeignKey(nameof(IdPublSpons))]
        [InverseProperty(nameof(Publication.Sponsorises))]
        public virtual Publication IdPublSponsNavigation { get; set; }
    }
}
