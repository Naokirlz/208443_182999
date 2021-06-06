using Negocio.Categorias;
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

        public Contexto() : base("name=Contexto")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //usa los DataAnnotation
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.Add(new CatogoriaTypeConfiguration());
        }
    }
}
