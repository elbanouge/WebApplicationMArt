using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    public partial class Medium
    {
        [Key]
        [Column("idMed")]
        public int IdMed { get; set; }
        [Column("titreMed")]
        [StringLength(250)]
        public string TitreMed { get; set; }
        [Column("imageMed")]
        [MaxLength(1)]
        public byte[] ImageMed { get; set; }
        [Column("audioMed")]
        [MaxLength(1)]
        public byte[] AudioMed { get; set; }
        [Column("videoMed", TypeName = "text")]
        public string VideoMed { get; set; }
        [Column("idPublMed")]
        public int? IdPublMed { get; set; }

        [ForeignKey(nameof(IdPublMed))]
        [InverseProperty(nameof(Publication.Media))]
        public virtual Publication IdPublMedNavigation { get; set; }
    }
}
