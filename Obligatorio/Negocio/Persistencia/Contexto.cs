using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.TarjetaCreditos;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Persistencia
{
    public class Contexto : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TarjetaCredito> Tarjetas { get; set; }

        public DbSet<Contrasenia> Contrasenias { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<FuenteLocal> FuentesLocales { get; set; }
        public DbSet<FuenteArchivo> FuentesArchivos{ get; set; }
        public DbSet<DataBreach> DataBreaches { get; set; }

        public Contexto() : base("name=Contexto")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //usa los DataAnnotation
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Contrasenia>().Property(e => e.FechaUltimaModificacion).HasColumnType("datetime2");
            modelBuilder.Entity<Password>().Property(e => e.Clave).IsRequired();
            modelBuilder.Entity<Fuente>().ToTable("Fuentes");
            modelBuilder.Entity<DataBreach>().HasKey(t => new { t.FuenteId, t.Texto });

        }
    }
}
