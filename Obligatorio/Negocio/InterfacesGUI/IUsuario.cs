using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public interface IUsuario
    {
        void Login(string password);
        bool VerificarUsuarioExiste();
        void GuardarPrimerPassword(string primerPassword);
        void Logout();
    }
}
