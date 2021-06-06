using Negocio.Categorias;
using Negocio.Utilidades;
using System.Collections.Generic;

namespace Negocio.Persistencia
{
    public class RepositorioCategoriasMemoria : IRepositorio<Categoria>
    {
        private static int autonumerado = 1;
        private List<Categoria> categorias;

        public RepositorioCategoriasMemoria()
        {
            this.categorias = new List<Categoria>();
        }

        public int Alta(Categoria categoria)
        {
            Existe(categoria);
            Categoria nueva = new Categoria(categoria.Nombre);
            nueva.Id = autonumerado;
            autonumerado++;
            this.categorias.Add(nueva);
            return nueva.Id;
        }

        public void Baja(Categoria categoria)
        {
            categorias.Remove(Buscar(categoria));
        }

        public void Modificar(Categoria categoria)
        {
            Existe(categoria);
            Categoria Modificar = Buscar(categoria);
            Modificar.Nombre = categoria.Nombre;
        }

        public Categoria Buscar(Categoria categoria)
        {
            foreach (Categoria item in this.categorias)
            {
                if (item.Id == categoria.Id)
                {
                    return item;
                }
            }
            throw new ExcepcionElementoNoExiste("Error: Categoría No Existe !!!");
        }

        public IEnumerable<Categoria> ObtenerTodas()
        {
            return this.categorias;
        }

        public void Existe(Categoria categoria)
        {
            foreach (var item in this.categorias)
            {
                if (item.Nombre.Equals(categoria.Nombre))
                    throw new ExcepcionElementoYaExiste("Ya existe categoría con ese nombre.");
            }
        }
    }
}
