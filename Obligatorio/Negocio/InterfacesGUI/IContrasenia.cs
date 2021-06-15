using Negocio.Categorias;
using Negocio.Contrasenias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public interface IContrasenia
    {
        IEnumerable<Categoria> ObtenerTodasLasCategorias();
        int AltaContrasenia(Contrasenia unaContrasena);
        int VerificarPasswordFiltrado(string password);
        int VerificarCatidadVecesPasswordRepetido(string password);
        string VerificarFortalezaPassword(string password);
        IEnumerable<Contrasenia> ObtenerTodasLasContrasenias();
        void BajaContrasenia(int id);
        string MostrarPassword(Contrasenia contrasenia);
        void ModificarContrasenia(Contrasenia modificada);
        IEnumerable<Grupo> GenerarGrupos();
    }
}
