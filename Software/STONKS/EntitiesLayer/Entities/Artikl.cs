namespace EntitiesLayer.Entities
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Artikli")]
    public partial class Artikl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artikl()
        {
            StavkePrimke = new HashSet<StavkaPrimke>();
            StavkeRacuna = new HashSet<StavkaRacuna>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(12)]
        public string sifra { get; set; }

        [Required]
        [StringLength(70)]
        public string naziv { get; set; }

        public int saldo { get; set; }

        public double jed_cijena { get; set; }

        public int pdv { get; set; }

        public int vrsta_artikla_id { get; set; }

        public int barkod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaPrimke> StavkePrimke { get; set; }

        public virtual VrstaArtikla VrsteArtikla { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaRacuna> StavkeRacuna { get; set; }
    }
}
