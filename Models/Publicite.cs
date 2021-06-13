using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Publicite")]
    public partial class Publicite
    {
        public Publicite()
        {
            Paiements = new HashSet<Paiement>();
        }

        [Key]
        [Column("idPub")]
        public int IdPub { get; set; }

        [InverseProperty(nameof(Paiement.IdPubPayNavigation))]
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
