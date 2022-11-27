namespace EntitiesLayer.Entities
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Dobavljaci")]
    public partial class Dobavljac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dobavljac()
        {
            Primke = new HashSet<Primka>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(45)]
        public string naziv { get; set; }

        [Required]
        [StringLength(11)]
        public string OIB { get; set; }

        [StringLength(200)]
        public string adresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Primka> Primke { get; set; }
    }
}
