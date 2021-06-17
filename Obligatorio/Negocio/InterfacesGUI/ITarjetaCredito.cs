using Negocio.Categorias;
using Negocio.TarjetaCreditos;
using System.Collections.Generic;

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
