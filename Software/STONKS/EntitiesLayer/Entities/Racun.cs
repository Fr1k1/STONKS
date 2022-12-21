namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Racuni")]
    public partial class Racun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Racun()
        {
            StavkeRacuna = new HashSet<StavkaRacuna>();
        }

        public int id { get; set; }

        public DateTime vrijeme_izdavanja { get; set; }

       // [Required]
       // [StringLength(45)]
        //public string nacin_placanja { get; set; } // ovo se treba maknut ja mislim jer tog nema u bazi

        public double cjena_bez_pdv { get; set; }

        public double pdv { get; set; }

        public double? popust { get; set; }

        public double ukupno { get; set; }

        public int korisnik_id { get; set; }

        public int nacin_placanja_id { get; set; }

        public virtual Korisnik Korisnici { get; set; }

        public virtual NacinPlacanja NaciniPlacanja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaRacuna> StavkeRacuna { get; set; }
    }
}
