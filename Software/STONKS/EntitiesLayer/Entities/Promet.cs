namespace EntitiesLayer.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Prometi")]
    public partial class Promet
    {
        public int id { get; set; }

       /* public double gotovina { get; set; }

        public double? popust_gotovina { get; set; }

        [Required]
        [StringLength(45)]
        public string ukupna_gotovina { get; set; }

        public double kartice { get; set; }

        public double popust_kartice { get; set; }

        public double ukupno_kartice { get; set; }

        public double porez { get; set; }

        public double ukupno_promet { get; set; }

        public double? ukupni_popust { get; set; }*/

        public DateTime datum_vrijeme { get; set; }

        public int korisnik_id { get; set; }

        public virtual Korisnik Korisnici { get; set; }
    }
}
