using Negocio.Categorias;
using System.Collections.Generic;

namespace Negocio.InterfacesGUI
{
    public interface ICategoria
    {
        void AltaCategoria(string nombre);
        void BajaCategoria(int categoriaId);
        void ModificarCategoria(int id, string nombreNuevo);
        IEnumerable<Categoria> ObtenerTodasLasCategorias();
    }
}
