using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Administrateur")]
    public partial class Administrateur
    {
        [Key]
        [Column("idAd")]
        public int IdAd { get; set; }
        [Column("loginAd")]
        [StringLength(250)]
        public string LoginAd { get; set; }
        [Column("passAd")]
        [StringLength(250)]
        public string PassAd { get; set; }
    }
}
