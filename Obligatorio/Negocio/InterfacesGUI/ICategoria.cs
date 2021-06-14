using Negocio.Categorias;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public interface ICategoria
    {
        void AltaCategoria(string nombre);
        void BajaCategoria(int categoriaId);
        IEnumerable<Categoria> ObtenerTodasLasCategorias();

    }
}
