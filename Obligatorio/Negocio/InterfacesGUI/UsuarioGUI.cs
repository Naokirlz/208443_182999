using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public class UsuarioGUI : IUsuario
    {
        private Sesion sesion = Sesion.ObtenerInstancia();

        public void GuardarPrimerPassword(string primerPassword)
        {
            sesion.GuardarPrimerPassword(primerPassword);
        }

        public void Login(string password)
        {
            sesion.Login(password);
        }

        public bool VerificarUsuarioExiste()
        {
            return sesion.VerificarUsuarioExiste();
        }
    }
}
