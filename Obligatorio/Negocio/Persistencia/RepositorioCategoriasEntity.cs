using Negocio.Categorias;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
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
                context.Categorias.Remove(aEliminar);
                context.SaveChanges();
            }
        }

        public Categoria Buscar(Categoria entity)
        {
            using (Contexto context = new Contexto())
            {
                return context.Categorias.Find(entity.Id);
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
    }
}
