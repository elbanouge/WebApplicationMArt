using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace WebApplicationMArt.Models
{
    public partial class MArtContext : DbContext
    {
        public MArtContext()
        {
        }

        public MArtContext(DbContextOptions<MArtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrateur> Administrateurs { get; set; }
        public virtual DbSet<Evenement> Evenements { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Paiement> Paiements { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Publicite> Publicites { get; set; }
        public virtual DbSet<Reagir> Reagirs { get; set; }
        public virtual DbSet<Reserver> Reservers { get; set; }
        public virtual DbSet<Sponsorise> Sponsorises { get; set; }
        public virtual DbSet<Suivre> Suivres { get; set; }
        public virtual DbSet<Utllisateur> Utllisateurs { get; set; }

        //public IConfiguration Configuration { get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MArt;Integrated Security=True");
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Administrateur>(entity =>
            {
                entity.HasKey(e => e.IdAd)
                    .HasName("PK__Administ__9DB8A680FF725C27");

                entity.Property(e => e.LoginAd).IsUnicode(false);

                entity.Property(e => e.PassAd).IsUnicode(false);
            });

            modelBuilder.Entity<Evenement>(entity =>
            {
                entity.HasKey(e => e.IdEvn)
                    .HasName("PK__Evenemen__3F0AB92371005BDA");

                entity.Property(e => e.DescrEvn).IsUnicode(false);

                entity.Property(e => e.ImageEvn).IsFixedLength(true);

                entity.Property(e => e.SloganEvn).IsUnicode(false);

                entity.Property(e => e.TitreEvn).IsUnicode(false);

                entity.Property(e => e.TypeEvn).IsUnicode(false);

                entity.HasOne(d => d.IdUtlEvenNavigation)
                    .WithMany(p => p.Evenements)
                    .HasForeignKey(d => d.IdUtlEven)
                    .HasConstraintName("FK__Evenement__idUtl__2F10007B");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdG)
                    .HasName("PK__Genre__DC501A2962B26463");

                entity.Property(e => e.TypeG).IsUnicode(false);
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.HasKey(e => e.IdMed)
                    .HasName("PK__Media__3DC6EB8923E83053");

                entity.Property(e => e.AudioMed).IsFixedLength(true);

                entity.Property(e => e.ImageMed).IsFixedLength(true);

                entity.Property(e => e.TitreMed).IsUnicode(false);

                entity.HasOne(d => d.IdPublMedNavigation)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.IdPublMed)
                    .HasConstraintName("FK__Media__idPublMed__398D8EEE");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.IdNot)
                    .HasName("PK__Notifica__3FF094240CA27BAA");

                entity.HasOne(d => d.IdUtlNotNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.IdUtlNot)
                    .HasConstraintName("FK__Notificat__idUtl__2A4B4B5E");
            });

            modelBuilder.Entity<Paiement>(entity =>
            {
                entity.HasKey(e => e.IdPay)
                    .HasName("PK__Paiement__3D783EEA043B586E");

                entity.HasOne(d => d.IdEvnPayNavigation)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdEvnPay)
                    .HasConstraintName("FK__Paiement__idEvnP__3C69FB99");

                entity.HasOne(d => d.IdPubPayNavigation)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdPubPay)
                    .HasConstraintName("FK__Paiement__idPubP__3F466844");

                entity.HasOne(d => d.IdPublPayNavigation)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdPublPay)
                    .HasConstraintName("FK__Paiement__idPubl__3E52440B");

                entity.HasOne(d => d.IdUtlPayNavigation)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdUtlPay)
                    .HasConstraintName("FK__Paiement__idUtlP__3D5E1FD2");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasKey(e => e.IdP)
                    .HasName("PK__Publicat__DC501A200424720A");

                entity.Property(e => e.TitreP).IsUnicode(false);

                entity.HasOne(d => d.IdGenrePublNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IdGenrePubl)
                    .HasConstraintName("FK__Publicati__idGen__36B12243");

                entity.HasOne(d => d.IdUtlPublNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IdUtlPubl)
                    .HasConstraintName("FK__Publicati__idUtl__35BCFE0A");
            });

            modelBuilder.Entity<Publicite>(entity =>
            {
                entity.HasKey(e => e.IdPub)
                    .HasName("PK__Publicit__3D79530CF6CFEB68");
            });

            modelBuilder.Entity<Reagir>(entity =>
            {
                entity.HasKey(e => new { e.IdPublRea, e.IdUtlRea })
                    .HasName("PK__Reagir__E541299C7F5D0F84");

                entity.HasOne(d => d.IdPublReaNavigation)
                    .WithMany(p => p.Reagirs)
                    .HasForeignKey(d => d.IdPublRea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reagir__idPublRe__45F365D3");

                entity.HasOne(d => d.IdUtlReaNavigation)
                    .WithMany(p => p.Reagirs)
                    .HasForeignKey(d => d.IdUtlRea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reagir__idUtlRea__46E78A0C");
            });

            modelBuilder.Entity<Reserver>(entity =>
            {
                entity.HasKey(e => new { e.IdUtlRes, e.IdEvenRes })
                    .HasName("PK__Reserver__AC6B0D74FE51145B");

                entity.HasOne(d => d.IdEvenResNavigation)
                    .WithMany(p => p.Reservers)
                    .HasForeignKey(d => d.IdEvenRes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserver__idEven__4316F928");

                entity.HasOne(d => d.IdUtlResNavigation)
                    .WithMany(p => p.Reservers)
                    .HasForeignKey(d => d.IdUtlRes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserver__idUtlR__4222D4EF");
            });

            modelBuilder.Entity<Sponsorise>(entity =>
            {
                entity.HasKey(e => new { e.IdPublSpons, e.IdPaySpons })
                    .HasName("PK__Sponsori__B35AE6E7F86956E1");

                entity.HasOne(d => d.IdPaySponsNavigation)
                    .WithMany(p => p.Sponsorises)
                    .HasForeignKey(d => d.IdPaySpons)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sponsoris__idPay__4AB81AF0");

                entity.HasOne(d => d.IdPublSponsNavigation)
                    .WithMany(p => p.Sponsorises)
                    .HasForeignKey(d => d.IdPublSpons)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sponsoris__idPub__49C3F6B7");
            });

            modelBuilder.Entity<Suivre>(entity =>
            {
                entity.HasKey(e => new { e.IdUtlSuivre, e.IdUtlFsuivre })
                    .HasName("PK__Suivre__85BF65BB2128F501");

                entity.HasOne(d => d.IdUtlFsuivreNavigation)
                    .WithMany(p => p.SuivreIdUtlFsuivreNavigations)
                    .HasForeignKey(d => d.IdUtlFsuivre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suivre__idUtlFSu__276EDEB3");

                entity.HasOne(d => d.IdUtlSuivreNavigation)
                    .WithMany(p => p.SuivreIdUtlSuivreNavigations)
                    .HasForeignKey(d => d.IdUtlSuivre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suivre__idUtlSui__267ABA7A");
            });

            modelBuilder.Entity<Utllisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtl)
                    .HasName("PK__Utllisat__03D70455CCC10F2B");

                entity.Property(e => e.AdresseUtl).IsUnicode(false);

                entity.Property(e => e.DomaineUtl).IsUnicode(false);

                entity.Property(e => e.EmailUtl).IsUnicode(false);

                entity.Property(e => e.ImageUtl).IsFixedLength(true);

                entity.Property(e => e.MotPassUtl).IsUnicode(false);

                entity.Property(e => e.NomUtl).IsUnicode(false);

                entity.Property(e => e.PaysUtl).IsUnicode(false);

                entity.Property(e => e.PrenomUtl).IsUnicode(false);

                entity.Property(e => e.TelUtl).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
