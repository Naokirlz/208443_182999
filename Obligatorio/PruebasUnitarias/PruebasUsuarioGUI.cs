using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Excepciones;
using Negocio.InterfacesGUI;
using System;
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
            //usuarioGUI.GuardarPrimerPassword("secreto");
            //usuarioGUI.Login("secreto");
            //int id = usuarioGUI.AltaCategoria("Cosas");
            //Categoria nuevaCategoriaPrueba = usuarioGUI.BuscarCategoriaPorId(id);

            //this.nuevoTarjeta = new TarjetaCredito()
            //{
            //    Categoria = nuevaCategoriaPrueba,
            //    Nombre = "PruebaNombre",
            //    Tipo = "PruebaTipo",
            //    Numero = "1234123412341234",
            //    Codigo = "123",
            //    Vencimiento = DateTime.Now,
            //    Nota = "Nota Opcional",

            //};

            //this.pruebaContrasenia = new Contrasenia()
            //{
            //    Sitio = "deremate.com",
            //    Usuario = "fedex",
            //    Password = new Password("dalevo111!!!"),
            //    Categoria = nuevaCategoriaPrueba,
            //    Notas = "Sin"
            //};

            //usuarioGUI.AltaTarjetaCredito(nuevoTarjeta);
            //usuarioGUI.AltaContrasenia(pruebaContrasenia);
            //FuenteLocal fuente = new FuenteLocal();
            //usuarioGUI.CargarDataBreach(fuente, "dalevo111!!!\n1234123412341234");
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
