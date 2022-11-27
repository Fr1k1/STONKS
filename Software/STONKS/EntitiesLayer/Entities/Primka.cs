namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Primke")]
    public partial class Primka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Primka()
        {
            StavkePrimke = new HashSet<StavkaPrimke>();
        }

        public int id { get; set; }

        public double ukupno { get; set; }

        public DateTime datum { get; set; }

        public int Dobavljac_id { get; set; }

        public virtual Dobavljac Dobavljaci { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaPrimke> StavkePrimke { get; set; }
    }
}
