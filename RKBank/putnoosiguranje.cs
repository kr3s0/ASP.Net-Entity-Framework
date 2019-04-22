namespace RKBank
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rk_baza.putnoosiguranje")]
    public partial class putnoosiguranje
    {
        public int ID { get; set; }

        public int? OsiguranjeID { get; set; }

        [StringLength(13)]
        public string JMBG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumPocetka { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumZavrsetka { get; set; }

        public short? Status { get; set; }

        public int? Izlozenost { get; set; }

        public virtual klijent klijent { get; set; }

        public virtual osiguranje osiguranje { get; set; }
    }
}
