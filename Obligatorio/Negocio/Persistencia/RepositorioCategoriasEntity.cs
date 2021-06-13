using Negocio.Categorias;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Persistencia
{
    public class RepositorioCategoriasEntity : IRepositorio<Categoria>
    {
        private static int autonumerado = 1;
        public int Alta(Categoria entity)
        {
            using (Contexto context = new Contexto())
            {
                Existe(entity);
                context.Categorias.Add(entity);
                try 
                { 
                    context.SaveChanges();
                    autonumerado++;
                    return entity.Id;
                }
                
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Baja(Categoria entity)
        {
            using (Contexto context = new Contexto())
            {
                Categoria aEliminar = context.Categorias.FirstOrDefault(c => c.Id == entity.Id);

                if (aEliminar != null)
                {
                    context.Categorias.Remove(aEliminar);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else throw new ExcepcionElementoNoExiste("Error: Categoría No Existe !!!");
            }
        }

        public Categoria Buscar(Categoria entity)
        {
            using (Contexto context = new Contexto())
            {
                Categoria buscada;
                
                    buscada = context.Categorias.Find(entity.Id);
                    if (buscada != null)
                    {
                        return buscada;
                    }
                    throw new ExcepcionElementoNoExiste("Error: Categoría No Existe !!!");
             }

        }

        public void Existe(Categoria entity)
        {

            using (Contexto context = new Contexto())
            {
                Categoria existe = context.Categorias.FirstOrDefault(c => c.Nombre == entity.Nombre);
                if (existe != null)
                    throw new ExcepcionElementoYaExiste("Ya existe categoría con ese nombre.");
            }

        }

        public void Modificar(Categoria entity)
        {
            using (Contexto context = new Contexto())
            {

                Existe(entity);
                Categoria categoriaAModificar = context.Categorias.FirstOrDefault(c => c.Id == entity.Id);
                categoriaAModificar.Nombre = entity.Nombre;
                
                context.SaveChanges();
              
               
            }

        }


        public void TestClear()
        {
            using (Contexto context = new Contexto())
            {
                //context.Tarjetas.RemoveRange(context.Tarjetas);
                //context.Passwords.RemoveRange(context.Passwords);
               // context.Contrasenias.RemoveRange(context.Contrasenias);
                context.Categorias.RemoveRange(context.Categorias);
                context.SaveChanges();
            }


        }

        public IEnumerable<Categoria> ObtenerTodas()
        {
            using (Contexto context = new Contexto())
            {
                return context.Categorias.ToList();
            }
        }
    }
}
