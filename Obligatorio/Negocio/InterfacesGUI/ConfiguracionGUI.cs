using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public class ConfiguracionGUI : IConfiguracion
    {
        private Sesion sesion;
        public ConfiguracionGUI()
        {
            sesion = Sesion.ObtenerInstancia();
        }

        public void BajaCategoria(int id)
        {
            sesion.BajaCategoria(id);
        }

        public void BajaContrasenia(int id)
        {
            sesion.BajaContrasenia(id);
        }

        public void LimpiarFuentes()
        {
            sesion.LimpiarFuentes();
        }

        public void BajaHistorial(int id)
        {
            sesion.BajaHistorial(id);
        }

        public void BajaTarjetaCredito(int id)
        {
            sesion.BajaTarjetaCredito(id);
        }

        public void CambiarContextoDeBaseDeDatos(string contexto)
        {
            sesion.CambiarContextoDeBaseDeDatos(contexto);
        }

        public void CambiarPassword(string nuevoPassword)
        {
            sesion.CambiarPassword(nuevoPassword);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            return sesion.ObtenerTodasLasCategorias();
        }

        public IEnumerable<Contrasenia> ObtenerTodasLasContrasenias()
        {
            return sesion.ObtenerTodasLasContrasenias();
        }

        public IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas()
        {
            return sesion.ObtenerTodasLasTarjetas();
        }

        public IEnumerable<Historial> ObtenerTodasLosHistoriales()
        {
            return sesion.ObtenerTodasLosHistoriales();
        }

        public void VaciarDatosPrueba()
        {
            sesion.VaciarDatosPrueba();
        }
    }
}
