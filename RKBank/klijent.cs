namespace RKBank
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rk_baza.klijent")]
    public partial class klijent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public klijent()
        {
            imovinskoosiguranje = new HashSet<imovinskoosiguranje>();
            kartica = new HashSet<kartica>();
            kredit = new HashSet<kredit>();
            osiguranje = new HashSet<osiguranje>();
            putnoosiguranje = new HashSet<putnoosiguranje>();
            zivotnoosiguranje = new HashSet<zivotnoosiguranje>();
        }

        [Key]
        [StringLength(13)]
        public string JMBG { get; set; }

        [StringLength(20)]
        public string Ime { get; set; }

        [StringLength(30)]
        public string Prezime { get; set; }

        [StringLength(50)]
        public string AdresaStanovanja { get; set; }

        [StringLength(50)]
        public string Zaposlenje { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumRodjenja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imovinskoosiguranje> imovinskoosiguranje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kartica> kartica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kredit> kredit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<osiguranje> osiguranje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<putnoosiguranje> putnoosiguranje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zivotnoosiguranje> zivotnoosiguranje { get; set; }
    }
}
