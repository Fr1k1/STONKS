namespace EntitiesLayer.Entities
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VrsteArtikla")]
    public partial class VrstaArtikla
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VrstaArtikla()
        {
            Artikli = new HashSet<Artikl>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(45)]
        public string naziv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artikl> Artikli { get; set; }
    }
}
