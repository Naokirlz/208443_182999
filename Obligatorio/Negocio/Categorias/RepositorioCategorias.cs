using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Categoria Alta(string nombre)
        {
            Categoria nueva = new Categoria(nombre);
            nueva.Id = autonumerado;
            autonumerado++;
            this.Categorias.Add(nueva);
            return nueva;
        }

        internal void Baja(int id)
        {
            Categoria eliminar = BuscarCategoriaPorId(id);
            Categorias.Remove(eliminar);
        }

        public void Modificacion(int id, string nuevoNombre)
        {
            Categoria Modificar = BuscarCategoriaPorId(id);
            Modificar.Nombre = nuevoNombre;
         }

        public bool ExisteCategoria(string nombre)
        {
            foreach (var categoria in this.Categorias)
            {
                if (categoria.Nombre.Equals(nombre)) return true;
            }
            return false;
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

    }
}
