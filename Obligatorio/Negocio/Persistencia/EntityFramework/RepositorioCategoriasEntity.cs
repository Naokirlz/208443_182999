using Negocio.Categorias;
using Negocio.Excepciones;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Negocio.Persistencia.EntityFramework
{
    public class RepositorioCategoriasEntity : IRepositorio<Categoria>
    {
        private static int autonumerado = 1;
        private string contexto;
        public int Alta(Categoria entity)
        {
            contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
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
            contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
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
            contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
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
            contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                Categoria existe = context.Categorias.FirstOrDefault(c => c.Nombre == entity.Nombre);
                if (existe != null)
                    throw new ExcepcionElementoYaExiste("Ya existe categoría con ese nombre.");
            }
        }

        public void Modificar(Categoria entity)
        {
            contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                Existe(entity);
                Categoria categoriaAModificar = context.Categorias.FirstOrDefault(c => c.Id == entity.Id);
                categoriaAModificar.Nombre = entity.Nombre;
                context.SaveChanges();
            }
        }
       
        public IEnumerable<Categoria> ObtenerTodas()
        {
            contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                return context.Categorias.ToList();
            }
        }

        public void TestClear()
        {
            contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            using (Contexto context = new Contexto(contexto))
            {
                context.Categorias.RemoveRange(context.Categorias);
                context.SaveChanges();
            }
        }
    }
}
