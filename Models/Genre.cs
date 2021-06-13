using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMArt.Models
{
    [Table("Genre")]
    public partial class Genre
    {
        public Genre()
        {
            Publications = new HashSet<Publication>();
        }

        [Key]
        [Column("idG")]
        public int IdG { get; set; }
        [Column("typeG")]
        [StringLength(250)]
        public string TypeG { get; set; }

        [InverseProperty(nameof(Publication.IdGenrePublNavigation))]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
