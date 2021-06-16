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
    public interface IConfiguracion
    {
        void CambiarPassword(string nuevoPassword);
        void CambiarContextoDeBaseDeDatos(string contexto);
        void VaciarDatosPrueba();
        void BajaDataBreachArchivos();
        IEnumerable<Historial> ObtenerTodasLosHistoriales();
        void BajaHistorial(int id);
        void BajaDataBreachLocal();
        IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas();
        void BajaTarjetaCredito(int id);
        IEnumerable<Contrasenia> ObtenerTodasLasContrasenias();
        void BajaContrasenia(int id);
        IEnumerable<Categoria> ObtenerTodasLasCategorias();
        void BajaCategoria(int id);
    }
}
