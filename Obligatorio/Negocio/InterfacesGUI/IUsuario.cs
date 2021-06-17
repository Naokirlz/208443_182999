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
