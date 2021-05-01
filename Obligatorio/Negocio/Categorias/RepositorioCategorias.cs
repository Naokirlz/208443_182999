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
        private List<Categoria> Categorias { get; set; }

        public RepositorioCategorias()
        {
            this.Categorias = new List<Categoria>();
        }

        public Categoria Alta(string nombre)
        {
            Categoria nueva = new Categoria(nombre);
            this.Categorias.Add(nueva);
            return nueva;
        }

        internal void Baja(int id)
        {
            Categorias.Remove(BuscarCategoriaPorId(id));
           
        }

        public void Modificacion(int id, string nuevoNombre)
        {
            Categoria Modificar = BuscarCategoriaPorId(id);
            Modificar.Nombre = nuevoNombre;
            
        }

        public bool ExisteCategoria(string unNombre)
        {
            foreach (var categoria in this.Categorias)
            {
                if (categoria.Nombre.Equals(unNombre)) return true;
            }
            return false;
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            foreach (Categoria categoria in this.Categorias)
            {
                if (categoria.Id == id) { return categoria; }
            }
            throw new ExcepcionElementoNoExiste();
        }

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> clon = new List<Categoria>();
            foreach (Categoria cat in Categorias)
            {
                Categoria clonCat = new Categoria(cat.Nombre, cat.Id);
                clon.Add(clonCat);
            }
            return clon;
        }


       
    }
}
