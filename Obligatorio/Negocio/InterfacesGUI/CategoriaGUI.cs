using Negocio.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public class CategoriaGUI : ICategoria
    {
        private Sesion sesion;
        public CategoriaGUI()
        {
            sesion = Sesion.ObtenerInstancia();
        }
        public int AltaCategoria(string nombre)
        {
            return sesion.AltaCategoria(nombre);
        }

        public void BajaCategoria(int categoriaId)
        {
            sesion.BajaCategoria(categoriaId);
        }

        public void ModificarCategoria(int id, string nombreNuevo)
        {
            sesion.ModificarCategoria(id, nombreNuevo);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            return sesion.ObtenerTodasLasCategorias();
        }
    }
}
