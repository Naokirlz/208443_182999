﻿using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.TarjetaCreditos;
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

        public Contexto() : base("name=Contexto")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //usa los DataAnnotation
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Contrasenia>().Property(e => e.FechaUltimaModificacion).HasColumnType("datetime2");
            //modelBuilder.Configurations.Add(new CatogoriaTypeConfiguration());
        }
    }
}