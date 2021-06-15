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
        private IVulnerablidades sesion;
        public CategoriaGUI()
        {
            sesion = IVulnerablidades.ObtenerInstancia();
        }
        public void AltaCategoria(string nombre)
        {
            sesion.AltaCategoria(nombre);
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
