using Negocio.Categorias;
using Negocio.TarjetaCreditos;
using System.Collections.Generic;

namespace Negocio.InterfacesGUI
{
    public class TarjetaCreditoGUI : ITarjetaCredito
    {
        private Sesion sesion;
        public TarjetaCreditoGUI()
        {
            sesion = Sesion.ObtenerInstancia();
        }

        public int AltaTarjetaCredito(TarjetaCredito nuevaTarjeta)
        {
            return sesion.AltaTarjetaCredito(nuevaTarjeta);
        }

        public void BajaTarjetaCredito(int id)
        {
            sesion.BajaTarjetaCredito(id);
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            sesion.ModificarTarjeta(modificada);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            return sesion.ObtenerTodasLasCategorias();
        }

        public IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas()
        {
            return sesion.ObtenerTodasLasTarjetas();
        }
    }
}
