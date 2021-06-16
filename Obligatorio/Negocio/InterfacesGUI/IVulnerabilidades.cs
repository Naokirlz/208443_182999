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
    public interface IVulnerabilidades
    {
        void CargarDataBreach(IFuente fuente, string texto);
        IEnumerable<Historial> ObtenerTodasLosHistoriales();
        IEnumerable<HistorialContrasenia> DevolverContraseniasVulnerables(int historial);
        Contrasenia BuscarContrasenia(int id);
        IEnumerable<HistorialTarjetas> DevolverTarjetasVulnerables(int historial);
        int ConsultarVulnerabilidades();
        IEnumerable<Contrasenia> ContraseniasVulnerables();
        string MostrarPassword(Contrasenia contrasenia);
        IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables();
    }
}
