using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.TarjetaCreditos;
using System.Collections.Generic;

namespace Negocio.InterfacesGUI
{
    public interface IConfiguracion
    {
        void CambiarPassword(string nuevoPassword);
        void CambiarContextoDeBaseDeDatos(string contexto);
        void VaciarDatosPrueba();
        IEnumerable<Historial> ObtenerTodasLosHistoriales();
        void BajaHistorial(int id);
        void LimpiarFuentes();
        IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas();
        void BajaTarjetaCredito(int id);
        IEnumerable<Contrasenia> ObtenerTodasLasContrasenias();
        void BajaContrasenia(int id);
        IEnumerable<Categoria> ObtenerTodasLasCategorias();
        void BajaCategoria(int id);
    }
}
