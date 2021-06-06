﻿using Negocio.Categorias;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Negocio.Persistencia
{
    public class RepositorioTarjetaCreditoEntity : IRepositorio<TarjetaCredito>
    {
        public int Alta(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {

                context.Categorias.Attach(entity.Categoria);
                context.Tarjetas.Add(entity);

                try
                {
                    context.SaveChanges();
                    return entity.Id;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
                

            }
        }

        public void Baja(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {
                TarjetaCredito aEliminar = context.Tarjetas.FirstOrDefault(c => c.Id == entity.Id);
                context.Tarjetas.Remove(aEliminar);
                context.SaveChanges();
            }
        }

        public TarjetaCredito Buscar(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {
                return context.Tarjetas.Find(entity.Id);
            }
        }

        public void Existe(TarjetaCredito entity)
        {
            throw new NotImplementedException();
        }

        public void Modificar(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {
                TarjetaCredito tarjetaAModificar = context.Tarjetas.FirstOrDefault(c => c.Id == entity.Id);
                tarjetaAModificar = entity;
                context.SaveChanges();
            }
        }

        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            using (Contexto context = new Contexto())
            {
                return context.Tarjetas.Include(t => t.Categoria).ToList();
                    
            }
        }
    }
}
