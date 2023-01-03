using EntitiesLayer.Entities;
using System.Data.Entity;


namespace DataAccessLayer
{
    public partial class STONKS_DB : DbContext
    {
        public STONKS_DB()
            : base("name=STONKS_DB")
        {
        }

        public virtual DbSet<Artikl> Artikli { get; set; }
        public virtual DbSet<Dobavljac> Dobavljaci { get; set; }
        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<NacinPlacanja> NaciniPlacanja { get; set; }
        public virtual DbSet<Primka> Primke { get; set; }
        public virtual DbSet<Promet> Prometi { get; set; }
        public virtual DbSet<Racun> Racuni { get; set; }
        public virtual DbSet<StavkaPrimke> StavkePrimke { get; set; }
        public virtual DbSet<StavkaRacuna> StavkeRacuna { get; set; }
        public virtual DbSet<Uloga> Uloge { get; set; }
        public virtual DbSet<VrstaArtikla> VrsteArtikla { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikl>()
                .Property(e => e.sifra)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Artikl>()
                .Property(e => e.naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Artikl>()
                .HasMany(e => e.StavkePrimke)
                .WithRequired(e => e.Artikli)
                .HasForeignKey(e => e.artikl_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artikl>()
                .HasMany(e => e.StavkeRacuna)
                .WithRequired(e => e.Artikli)
                .HasForeignKey(e => e.artikl_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.OIB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.adresa)
                .IsUnicode(false);

            modelBuilder.Entity<Dobavljac>()
                .HasMany(e => e.Primke)
                .WithRequired(e => e.Dobavljaci)
                .HasForeignKey(e => e.Dobavljac_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.ime)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.prezime)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.OIB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.korime)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.lozinka)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.slika)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Prometi)
                .WithRequired(e => e.Korisnici)
                .HasForeignKey(e => e.korisnik_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Racuni)
                .WithRequired(e => e.Korisnici)
                .HasForeignKey(e => e.korisnik_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NacinPlacanja>()
                .Property(e => e.naziv)
                .IsUnicode(false);

            modelBuilder.Entity<NacinPlacanja>()
                .HasMany(e => e.Racuni)
                .WithRequired(e => e.NaciniPlacanja)
                .HasForeignKey(e => e.nacin_placanja_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Primka>()
                .HasMany(e => e.StavkePrimke)
                .WithRequired(e => e.Primke)
                .HasForeignKey(e => e.primka_id)
                .WillCascadeOnDelete(false);

            /*
                modelBuilder.Entity<Promet>()
                .Property(e => e.ukupna_gotovina)
                .IsUnicode(false);
            */
            /*
            modelBuilder.Entity<Racun>()
                .Property(e => e.nacin_placanja)
                .IsUnicode(false);*/
            
            modelBuilder.Entity<Racun>()
                .HasMany(e => e.StavkeRacuna)
                .WithRequired(e => e.Racuni)
                .HasForeignKey(e => e.racun_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Uloga>()
                .Property(e => e.naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Uloga>()
                .HasMany(e => e.Korisnici)
                .WithRequired(e => e.Uloge)
                .HasForeignKey(e => e.uloga_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VrstaArtikla>()
                .Property(e => e.naziv)
                .IsUnicode(false);

            modelBuilder.Entity<VrstaArtikla>()
                .HasMany(e => e.Artikli)
                .WithRequired(e => e.VrsteArtikla)
                .HasForeignKey(e => e.vrsta_artikla_id)
                .WillCascadeOnDelete(false);
        }
    }
}
