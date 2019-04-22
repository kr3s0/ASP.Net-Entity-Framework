namespace RKBank
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RKBankDBModel : DbContext
    {
        public RKBankDBModel()
            : base("name=RKBankDBModel")
        {
        }

        public virtual DbSet<imovinskoosiguranje> imovinskoosiguranje { get; set; }
        public virtual DbSet<kartica> kartica { get; set; }
        public virtual DbSet<klijent> klijent { get; set; }
        public virtual DbSet<kredit> kredit { get; set; }
        public virtual DbSet<osiguranje> osiguranje { get; set; }
        public virtual DbSet<putnoosiguranje> putnoosiguranje { get; set; }
        public virtual DbSet<zivotnoosiguranje> zivotnoosiguranje { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<imovinskoosiguranje>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<kartica>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<klijent>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<klijent>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<klijent>()
                .Property(e => e.Prezime)
                .IsUnicode(false);

            modelBuilder.Entity<klijent>()
                .Property(e => e.AdresaStanovanja)
                .IsUnicode(false);

            modelBuilder.Entity<klijent>()
                .Property(e => e.Zaposlenje)
                .IsUnicode(false);

            modelBuilder.Entity<kredit>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<osiguranje>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<putnoosiguranje>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<zivotnoosiguranje>()
                .Property(e => e.JMBG)
                .IsUnicode(false);
        }
    }
}
