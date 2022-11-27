namespace EntitiesLayer.Entities
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("NaciniPlacanja")]
    public partial class NacinPlacanja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NacinPlacanja()
        {
            Racuni = new HashSet<Racun>();
        }

        public int id { get; set; }

        [StringLength(45)]
        public string naziv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuni { get; set; }
    }
}
