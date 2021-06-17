using Negocio.Categorias;
using Negocio.Contrasenias;
using System.Collections.Generic;

namespace Negocio.InterfacesGUI
{
    public class ContraseniaGUI : IContrasenia
    {
        private Sesion sesion;
        public ContraseniaGUI()
        {
            sesion = Sesion.ObtenerInstancia();
        }

        public int AltaContrasenia(Contrasenia unaContrasena)
        {
            return sesion.AltaContrasenia(unaContrasena);
        }

        public void BajaContrasenia(int id)
        {
            sesion.BajaContrasenia(id);
        }

        public IEnumerable<Grupo> GenerarGrupos()
        {
            return sesion.GenerarGrupos();
        }

        public void ModificarContrasenia(Contrasenia modificada)
        {
            sesion.ModificarContrasenia(modificada);
        }

        public string MostrarPassword(Contrasenia contrasenia)
        {
            return sesion.MostrarPassword(contrasenia);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            return sesion.ObtenerTodasLasCategorias();
        }

        public IEnumerable<Contrasenia> ObtenerTodasLasContrasenias()
        {
            return sesion.ObtenerTodasLasContrasenias();
        }

        public int VerificarCatidadVecesPasswordRepetido(string password)
        {
            return sesion.VerificarCatidadVecesPasswordRepetido(password);
        }

        public string VerificarFortalezaPassword(string password)
        {
            return sesion.VerificarFortalezaPassword(password);
        }

        public int VerificarPasswordFiltrado(string password)
        {
            return sesion.VerificarPasswordFiltrado(password);
        }
    }
}
