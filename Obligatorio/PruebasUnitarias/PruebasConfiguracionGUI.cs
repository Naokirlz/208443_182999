using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.Excepciones;
using Negocio.InterfacesGUI;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasConfiguracionGUI
    {
        private IConfiguracion configuracionGUI;
        private Sesion sesion;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;


        [TestInitialize]
        public void InicializarPruebas()
        {

            sesion = Sesion.ObtenerInstancia();
            configuracionGUI = new ConfiguracionGUI();

            sesion.GuardarPrimerPassword("secreto");
            sesion.Login("secreto");
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            configuracionGUI.VaciarDatosPrueba();
            ConfigurationManager.AppSettings["DATABASE_CONTEXT"] = "ContextoUnitTest";
        }
        [TestMethod]
        public void SePuedeEjecutarBajaCategoriaEstandoLogueado()
        {
            sesion.AltaCategoria("NuevaCategoria");
            int cantidadAntes = configuracionGUI.ObtenerTodasLasCategorias().Count();
            Categoria unaCat = configuracionGUI.ObtenerTodasLasCategorias().First();
            configuracionGUI.BajaCategoria(unaCat.Id);
            int cantidadDespues = configuracionGUI.ObtenerTodasLasCategorias().Count();
            Assert.AreEqual(1, cantidadAntes - cantidadDespues);
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBajaContraseniaSiNoSeEstaLogueado()
        {
            sesion.LogOut();
            configuracionGUI.BajaContrasenia(1);
        }
        [TestMethod]
        public void SePuedeEjecutarBajaContraseniaEstandoLogueado()
        {
            int cantidadAntes = configuracionGUI.ObtenerTodasLasContrasenias().Count();
            configuracionGUI.BajaContrasenia(pruebaContrasenia.ContraseniaId);
            int cantidadDespues = configuracionGUI.ObtenerTodasLasContrasenias().Count();
            Assert.AreEqual(1, cantidadAntes - cantidadDespues);
        }
        [TestMethod]
        public void SePuedeEjecutarListarContraseniasEstandoLogueado()
        {
            Contrasenia buscada = configuracionGUI.ObtenerTodasLasContrasenias().First();
            Assert.IsNotNull(buscada);
        }
        [TestMethod]
        public void LaSesionPermiteEliminarLosArchivosDataBreach()
        {
            configuracionGUI.LimpiarFuentes();
            int contador = 0;
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (Directory.Exists(rutaDirectorio))
            {
                List<string> strFiles = Directory.GetFiles(rutaDirectorio, "*", SearchOption.AllDirectories).ToList();

                foreach (string fichero in strFiles)
                {
                    contador++;
                }
            }
            Assert.AreEqual(0, contador);
        }
        [TestMethod]
        public void LaSesionPermiteEliminarLaFuenteLocal()
        {
            int vecesVulnerableAntes = sesion.VerificarPasswordFiltrado("dalevo111!!!");
            configuracionGUI.LimpiarFuentes();
            int vecesVulnerableDespues = sesion.VerificarPasswordFiltrado("dalevo111!!!");
            Assert.AreNotEqual(vecesVulnerableAntes, vecesVulnerableDespues);
        }
        [TestMethod]
        public void SePuedeDarDeBajaUnHistorial()
        {
            int historial = sesion.ConsultarVulnerabilidades();
            configuracionGUI.BajaHistorial(historial);
            int cantidadHistoriales = configuracionGUI.ObtenerTodasLosHistoriales().Count();
            Assert.AreEqual(0, cantidadHistoriales);
        }
        [TestMethod]
        public void SePuedeEjecutarBajaTarjetaEstandoLogueado()
        {
            int antes = configuracionGUI.ObtenerTodasLasTarjetas().Count();
            configuracionGUI.BajaTarjetaCredito(nuevoTarjeta.Id);
            int despues = configuracionGUI.ObtenerTodasLasTarjetas().Count();
            Assert.AreEqual(1, antes - despues);
        }
        [TestMethod]
        public void SePuedeCambiarLaBaseDeDatos()
        {
            configuracionGUI.CambiarContextoDeBaseDeDatos("ContextoTest");
            string contexto = ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
            Assert.AreEqual("ContextoTest", contexto);
        }
        [TestMethod]
        public void SePuedeCambiarElPasswordEstandoLogueado()
        {
            configuracionGUI.CambiarPassword("cambio password");
            sesion.LogOut();
            sesion.Login("cambio password");

            int cantidadAntes = sesion.ObtenerTodasLasCategorias().Count();
            sesion.AltaCategoria("cat uno dos");
            int cantidadDespues = sesion.ObtenerTodasLasCategorias().Count();

            Assert.AreEqual(1, cantidadDespues - cantidadAntes);
        }
    }
}
