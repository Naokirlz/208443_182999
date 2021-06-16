using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.TarjetaCreditos;

namespace Negocio.InterfacesGUI
{
    public class VulnerabilidadesGUI : IVulnerabilidades
    {
        private Sesion sesion;
        public VulnerabilidadesGUI()
        {
            sesion = Sesion.ObtenerInstancia();
        }

        public Contrasenia BuscarContrasenia(int id)
        {
            return sesion.BuscarContrasenia(id);
        }

        public void CargarDataBreach(IFuente fuente, string texto)
        {
            sesion.CargarDataBreach(fuente, texto);
        }

        public int ConsultarVulnerabilidades()
        {
            return sesion.ConsultarVulnerabilidades();
        }

        public IEnumerable<Contrasenia> ContraseniasVulnerables()
        {
            return sesion.ContraseniasVulnerables();
        }

        public IEnumerable<HistorialContrasenia> DevolverContraseniasVulnerables(int historial)
        {
            return sesion.DevolverContraseniasVulnerables(historial);
        }

        public IEnumerable<HistorialTarjetas> DevolverTarjetasVulnerables(int historial)
        {
            return sesion.DevolverTarjetasVulnerables(historial);
        }

        public string MostrarPassword(Contrasenia contrasenia)
        {
            return sesion.MostrarPassword(contrasenia);
        }

        public IEnumerable<Historial> ObtenerTodasLosHistoriales()
        {
            return sesion.ObtenerTodasLosHistoriales();
        }

        public IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables()
        {
            return sesion.TarjetasCreditoVulnerables();
        }
    }
}
