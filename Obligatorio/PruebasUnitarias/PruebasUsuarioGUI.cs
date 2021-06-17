using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Excepciones;
using Negocio.InterfacesGUI;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasUsuarioGUI
    {
        private IUsuario usuarioGUI;
        private Sesion sesion;

        [TestInitialize]
        public void InicializarPruebas()
        {

            usuarioGUI = new UsuarioGUI();
            sesion = Sesion.ObtenerInstancia();
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesion.VaciarDatosPrueba();
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeGuardarElPasswordMaestroMenorA5Caracteres()
        {
            usuarioGUI.GuardarPrimerPassword("aaaa");
        }

        [TestMethod]
        public void SePuedeRealizarLogin()
        {
            usuarioGUI.GuardarPrimerPassword("aaazza");
            usuarioGUI.Login("aaazza");
            sesion.AltaCategoria("aaazza");
            Assert.IsTrue(sesion.ObtenerTodasLasCategorias().Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeGuardarElPasswordMaestroMayorA25Caracteres()
        {
            usuarioGUI.GuardarPrimerPassword("12345123451234512345123451");
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void FallaElLoginConPasswordIncorrecto()
        {
            string primerPassword = "nuevoPasswrod";
            usuarioGUI.GuardarPrimerPassword(primerPassword);
            usuarioGUI.Login("assassa");
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void ElUsuarioPuedeCerrarSesion()
        {
            string primerPassword = "nuevoPasswrod";
            usuarioGUI.GuardarPrimerPassword(primerPassword);
            usuarioGUI.Login("nuevoPasswrod");
            usuarioGUI.Logout();
            sesion.AltaCategoria("aaazza");
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeIniciarSesionSinIngresarElPrimerPassword()
        {
            usuarioGUI.Login("");
        }
        [TestMethod]
        public void SeVerificaSiElUsuarioExiste()
        {
            usuarioGUI.GuardarPrimerPassword("assassa");
            Assert.IsTrue(usuarioGUI.VerificarUsuarioExiste());
        }
    }
}
