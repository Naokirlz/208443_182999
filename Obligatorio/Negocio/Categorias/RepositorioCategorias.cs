using Negocio.Utilidades;
using System.Collections.Generic;

namespace Negocio.Categorias
{
    public class RepositorioCategorias
    {
        private static int autonumerado = 1;
        private List<Categoria> categorias;
        
        public RepositorioCategorias()
        {
            this.categorias = new List<Categoria>();
        }

        public int Alta(string nombre)
        {
            ExisteCategoria(nombre);
            Categoria nueva = new Categoria(nombre);
            nueva.Id = autonumerado;
            autonumerado++;
            this.categorias.Add(nueva);
            return nueva.Id;
        }

        public void Baja(int id)
        {
            categorias.Remove(BuscarCategoriaPorId(id));
        }

        public void ModificarCategoria(int id, string nuevoNombre)
        {
            ExisteCategoria(nuevoNombre);
            Categoria Modificar = BuscarCategoriaPorId(id);
            Modificar.Nombre = nuevoNombre;
         }
        
        public Categoria BuscarCategoriaPorId(int id)
        {
            foreach (Categoria categoria in this.categorias)
            {
                if (categoria.Id == id)
                { 
                    return categoria; 
                }
            }
            throw new ExcepcionElementoNoExiste("Error: Categoría No Existe !!!");
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            return this.categorias;
        }

        private void ExisteCategoria(string nombre)
        {
            foreach (var categoria in this.categorias)
            {
                if (categoria.Nombre.Equals(nombre))
                    throw new ExcepcionElementoYaExiste("Ya existe categoría con ese nombre.");
            }
        }
    }
}
