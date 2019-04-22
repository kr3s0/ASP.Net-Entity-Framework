namespace RKBank
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rk_baza.kredit")]
    public partial class kredit
    {
        public int ID { get; set; }

        public int? KarticaID { get; set; }

        [StringLength(13)]
        public string JMBG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumIzdavanja { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumPovratka { get; set; }

        public int? Izlozenost { get; set; }

        public short? Rizik { get; set; }

        public virtual kartica kartica { get; set; }

        public virtual klijent klijent { get; set; }
    }
}
