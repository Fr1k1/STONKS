namespace EntitiesLayer.Entities
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("StavkeRacuna")]
    public partial class StavkaRacuna
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int racun_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int artikl_id { get; set; }

        public int kolcina { get; set; }

        public double popust { get; set; }

        public double jed_cijena { get; set; }

        public double ukupno { get; set; }

        public virtual Artikl Artikli { get; set; }

        public virtual Racun Racuni { get; set; }
    }
}
