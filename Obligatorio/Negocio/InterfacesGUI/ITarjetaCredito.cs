using Negocio.Categorias;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public interface ITarjetaCredito
    {
        IEnumerable<Categoria> ObtenerTodasLasCategorias();
        int AltaTarjetaCredito(TarjetaCredito nuevaTarjeta);
        IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas();
        void BajaTarjetaCredito(int id);
        void ModificarTarjeta(TarjetaCredito modificada);
    }
}
