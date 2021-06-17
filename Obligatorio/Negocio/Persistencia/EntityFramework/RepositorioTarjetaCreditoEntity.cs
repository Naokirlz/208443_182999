using Negocio.TarjetaCreditos;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Negocio.Excepciones;
using System.Configuration;

namespace Negocio.Persistencia.EntityFramework
{
    public class RepositorioTarjetaCreditoEntity : IRepositorio<TarjetaCredito>
    {
        public int Alta(TarjetaCredito entity)
        {
            string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                Existe(entity);
                entity.Categoria = context.Categorias.FirstOrDefault(c => c.Nombre == entity.Categoria.Nombre);
                context.Categorias.Attach(entity.Categoria);
                context.Tarjetas.Add(entity);
                context.SaveChanges();
                return entity.Id;
             }
        }

        public void Baja(TarjetaCredito entity)
        {
            string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                TarjetaCredito aEliminar = context.Tarjetas.FirstOrDefault(c => c.Id == entity.Id);
                if (aEliminar != null)
                {
                    context.Tarjetas.Remove(aEliminar);
                    context.SaveChanges();
                
                }
                else throw new ExcepcionElementoNoExiste("Error: TarjetaCredito No Existe !!!");
            }
        }

        public TarjetaCredito Buscar(TarjetaCredito entity)
        {
            string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                TarjetaCredito existe = context.Tarjetas.Include(t => t.Categoria).FirstOrDefault(t => t.Id == entity.Id);
                if (existe != null) return existe;
                throw new ExcepcionElementoNoExiste("No existe Tarjeta!");
            }
        }

        public void Existe(TarjetaCredito entity)
        {
            string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                TarjetaCredito existe = context.Tarjetas.FirstOrDefault(c => (c.Numero == entity.Numero || c.Nombre == entity.Nombre) && c.Id != entity.Id);
                if (existe != null)
                    throw new ExcepcionElementoYaExiste("Ya existe Tarjeta con ese nombre o numero.");
            }
        }

        public void Modificar(TarjetaCredito entity)
        {
            string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
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
                context.Categorias.Attach(entity.Categoria);
                context.SaveChanges();
            }
        }

        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                List<TarjetaCredito> retorno;
                retorno = context.Tarjetas.Include(t => t.Categoria).ToList();
                retorno.Sort();
                return retorno;
            }
        }

        public void TestClear()
        {
            string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
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
