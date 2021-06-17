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

        public void Logout()
        {
            sesion.LogOut();
        }

        public bool VerificarUsuarioExiste()
        {
            return sesion.VerificarUsuarioExiste();
        }
    }
}
