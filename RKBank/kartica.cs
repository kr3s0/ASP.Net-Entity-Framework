namespace RKBank
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rk_baza.kartica")]
    public partial class kartica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kartica()
        {
            kredit = new HashSet<kredit>();
        }

        public int ID { get; set; }

        [StringLength(13)]
        public string JMBG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumIzdavanja { get; set; }

        public int? Stanje { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumIsteka { get; set; }

        public virtual klijent klijent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kredit> kredit { get; set; }
    }
}
