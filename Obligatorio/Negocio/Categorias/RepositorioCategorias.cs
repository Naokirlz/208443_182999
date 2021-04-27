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

            if (ExisteCategoria(nombre)) { throw new ExcepcionElementoYaExiste(); }
            this.Categorias.Add(nueva);
            return nueva;
        }

        internal bool Baja(int id)
        {
            Categorias.Remove(BuscarCategoria(id));
            return true;
        }

        public void ModificarCategoria(int id, string nuevoNombre)
        {
            Categoria Modificar = BuscarCategoria(id);
            if (ExisteCategoria(nuevoNombre)) throw new ExcepcionElementoYaExiste();
            Modificar.ModificarCategoria(nuevoNombre);
            Modificar.Nombre = nuevoNombre;
        }

        private bool ExisteCategoria(string unNombre)
        {
            foreach (var categoria in this.Categorias)
            {
                if (categoria.Nombre.Equals(unNombre)) return true;
            }
            return false;
        }

        public Categoria BuscarCategoria(int id)
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
