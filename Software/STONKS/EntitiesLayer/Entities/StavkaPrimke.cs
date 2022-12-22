namespace EntitiesLayer.Entities
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StavkePrimke")]
    public partial class StavkaPrimke
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int artikl_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int primka_id { get; set; }

        public double rabat { get; set; }

        public int kolicina { get; set; }

        public double ukupna_cijena { get; set; }

        public double nabavna_cijena { get; set; }

        public virtual Artikl Artikli { get; set; }

        public virtual Primka Primke { get; set; }
    }
}
