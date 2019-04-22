namespace RKBank
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rk_baza.osiguranje")]
    public partial class osiguranje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public osiguranje()
        {
            imovinskoosiguranje = new HashSet<imovinskoosiguranje>();
            putnoosiguranje = new HashSet<putnoosiguranje>();
            zivotnoosiguranje = new HashSet<zivotnoosiguranje>();
        }

        public int ID { get; set; }

        [StringLength(13)]
        public string JMBG { get; set; }

        public int? BrojAktivnih { get; set; }

        public int? BrojRizicnih { get; set; }

        public int? BrojZavrsenih { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imovinskoosiguranje> imovinskoosiguranje { get; set; }

        public virtual klijent klijent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<putnoosiguranje> putnoosiguranje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zivotnoosiguranje> zivotnoosiguranje { get; set; }
    }
}
