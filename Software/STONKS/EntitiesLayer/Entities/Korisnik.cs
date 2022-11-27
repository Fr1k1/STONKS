namespace EntitiesLayer.Entities
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Korisnici")]
    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            Prometi = new HashSet<Promet>();
            Racuni = new HashSet<Racun>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string ime { get; set; }

        [Required]
        [StringLength(70)]
        public string prezime { get; set; }

        [Required]
        [StringLength(11)]
        public string OIB { get; set; }

        [Required]
        [StringLength(45)]
        public string korime { get; set; }

        [Required]
        [StringLength(45)]
        public string lozinka { get; set; }

        public int uloga_id { get; set; }

        [Column(TypeName = "text")]
        public string slika { get; set; }

        public virtual Uloga Uloge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promet> Prometi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuni { get; set; }
    }
}
