using Negocio.Categorias;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Negocio.Utilidades;

namespace Negocio.Persistencia
{
    public class RepositorioTarjetaCreditoEntity : IRepositorio<TarjetaCredito>
    {
        public int Alta(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {
                Existe(entity);
                entity.Categoria = context.Categorias.FirstOrDefault(c => c.Nombre == entity.Categoria.Nombre);
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
                
                if (aEliminar != null)
                {
                    context.Tarjetas.Remove(aEliminar);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else throw new ExcepcionElementoNoExiste("Error: TarjetaCredito No Existe !!!");
            }
        }

        public TarjetaCredito Buscar(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {
                TarjetaCredito existe = context.Tarjetas.Include(t => t.Categoria).FirstOrDefault(t => t.Id == entity.Id);

                if (existe != null) return existe;
                throw new ExcepcionElementoNoExiste("No existe Tarjeta!");


            }
        }

        public void Existe(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {
                TarjetaCredito existe = context.Tarjetas.FirstOrDefault(c => (c.Numero == entity.Numero || c.Nombre == entity.Nombre) && c.Id != entity.Id);
                
                if (existe != null)
                    throw new ExcepcionElementoYaExiste("Ya existe Tarjeta con ese nombre o numero.");
            }
        }

        public void Modificar(TarjetaCredito entity)
        {
            using (Contexto context = new Contexto())
            {
                TarjetaCredito tarjetaAModificar = context.Tarjetas.FirstOrDefault(c => c.Id == entity.Id);
                tarjetaAModificar.Id = entity.Id;

                Existe(entity);

                tarjetaAModificar.Categoria = entity.Categoria;
                tarjetaAModificar.Nombre = entity.Nombre;
                tarjetaAModificar.Tipo = entity.Tipo;
                tarjetaAModificar.Numero = entity.Numero;
                tarjetaAModificar.Codigo = entity.Codigo;
                tarjetaAModificar.Vencimiento = entity.Vencimiento;
                tarjetaAModificar.Nota = entity.Nota;
                
                tarjetaAModificar.CantidadVecesEncontradaVulnerable = entity.CantidadVecesEncontradaVulnerable;

                try
                {
                    context.Categorias.Attach(entity.Categoria);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            using (Contexto context = new Contexto())
            {
                List<TarjetaCredito> retorno;
                retorno = context.Tarjetas.Include(t => t.Categoria).ToList();
                retorno.Sort();
                return retorno;
            }
        }

        public void TestClear()
        {
            using (Contexto context = new Contexto())
            {
                context.Tarjetas.RemoveRange(context.Tarjetas);
                context.Passwords.RemoveRange(context.Passwords);
                context.Contrasenias.RemoveRange(context.Contrasenias);
                context.Categorias.RemoveRange(context.Categorias);
                context.SaveChanges();
            }
        }
    }
}
