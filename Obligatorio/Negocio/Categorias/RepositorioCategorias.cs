using Negocio.Utilidades;
using System.Collections.Generic;

namespace Negocio.Categorias
{
    public class RepositorioCategorias
    {
        private static int autonumerado = 1;
        private List<Categoria> Categorias { get; set; }
        
        public RepositorioCategorias()
        {
            this.Categorias = new List<Categoria>();
        }

        public int Alta(string nombre)
        {
            ExisteCategoria(nombre);
            Categoria nueva = new Categoria(nombre);
            nueva.Id = autonumerado;
            autonumerado++;
            this.Categorias.Add(nueva);
            return nueva.Id;
        }

        public void Baja(int id)
        {
            Categorias.Remove(BuscarCategoriaPorId(id));
        }

        public void ModificarCategoria(int id, string nuevoNombre)
        {
            ExisteCategoria(nuevoNombre);
            Categoria Modificar = BuscarCategoriaPorId(id);
            Modificar.Nombre = nuevoNombre;
         }
        
        public Categoria BuscarCategoriaPorId(int id)
        {
            foreach (Categoria categoria in this.Categorias)
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
            return this.Categorias;
        }

        private void ExisteCategoria(string nombre)
        {
            foreach (var categoria in this.Categorias)
            {
                if (categoria.Nombre.Equals(nombre))
                    throw new ExcepcionElementoYaExiste("Ya existe categoría con ese nombre.");
            }
        }
    }
}
