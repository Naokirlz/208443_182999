using Negocio.Categorias;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Negocio.Persistencia.EntityFramework
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
                context.SaveChanges();
                autonumerado++;
                return entity.Id;
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
                    context.SaveChanges();
                  
                 
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
       
        public IEnumerable<Categoria> ObtenerTodas()
        {
            using (Contexto context = new Contexto())
            {
                return context.Categorias.ToList();
            }
        }

        public void TestClear()
        {
            using (Contexto context = new Contexto())
            {
                context.Categorias.RemoveRange(context.Categorias);
                context.SaveChanges();
            }
        }
    }
}
