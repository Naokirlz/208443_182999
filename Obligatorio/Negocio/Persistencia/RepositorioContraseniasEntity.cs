using Negocio.Contrasenias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Negocio.Persistencia
{
    public class RepositorioContraseniasEntity : IRepositorio<Contrasenia>
    {
        public int Alta(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                context.Categorias.Attach(entity.Categoria);
                context.Contrasenias.Add(entity);
                
                try
                {
                    context.SaveChanges();
                    return entity.ContraseniaId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Baja(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                Contrasenia aEliminar = context.Contrasenias.FirstOrDefault(c => c.ContraseniaId == entity.ContraseniaId);
                context.Passwords.Remove(aEliminar.Password);
                context.Contrasenias.Remove(aEliminar);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Contrasenia Buscar(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                return context.Contrasenias.Find(entity.ContraseniaId);
            }
        }

        public void Existe(Contrasenia entity)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                Contrasenia aModificar = context.Contrasenias.FirstOrDefault(c => c.ContraseniaId == entity.ContraseniaId);
                aModificar = entity;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            using (Contexto context = new Contexto())
            {
                return context.Contrasenias.Include(c => c.Password).Include(c => c.Categoria).ToList();

            }
        }
    }
}
