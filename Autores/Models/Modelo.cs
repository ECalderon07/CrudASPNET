namespace Autores.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Autor>()
                .Property(e => e.nacionalidad)
                .IsUnicode(false);
        }
    }
}
