using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.Excepciones;
using Negocio.InterfacesGUI;
using Negocio.TarjetaCreditos;
using System;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasCategoriaGUI
    {
        private ICategoria categoriaGUI;
        private Sesion sesion;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;

        [TestInitialize]
        public void InicializarPruebas()
        {

            categoriaGUI = new CategoriaGUI();
            sesion = Sesion.ObtenerInstancia();
            sesion.GuardarPrimerPassword("secreto");
            sesion.Login("secreto");

        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesion.VaciarDatosPrueba();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarAltaCategoriaSiNoSeEstaLogueado()
        {
            sesion.LogOut();
            categoriaGUI.AltaCategoria("cat uno");
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBajaCategoriaSiNoSeEstaLogueado()
        {
            sesion.LogOut();
            categoriaGUI.BajaCategoria(1);
        }
        [TestMethod]
        public void SePuedeEjecutarBajaCategoriaEstandoLogueado()
        {
            categoriaGUI.AltaCategoria("NuevaCategoria");
            int cantidadAntes = categoriaGUI.ObtenerTodasLasCategorias().Count();
            Categoria unaCat = categoriaGUI.ObtenerTodasLasCategorias().First();
            categoriaGUI.BajaCategoria(unaCat.Id);
            int cantidadDespues = categoriaGUI.ObtenerTodasLasCategorias().Count();
            Assert.AreEqual(1, cantidadAntes - cantidadDespues);
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarModificarCategoriaSiNoSeEstaLogueado()
        {
            sesion.LogOut();
            categoriaGUI.ModificarCategoria(1, "nuevoNombre");
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarObtenerTodasLasCategoriaSiNoSeEstaLogueado()
        {
            sesion.LogOut();
            categoriaGUI.ObtenerTodasLasCategorias();
        }
        [TestMethod]
        public void SePuedeEjecutarAltaCategoriaSiSeEstaLogueado()
        {
            int cantidadAntes = categoriaGUI.ObtenerTodasLasCategorias().Count();
            categoriaGUI.AltaCategoria("cat 123");
            int cantidadDespues = categoriaGUI.ObtenerTodasLasCategorias().Count();

            Assert.AreEqual(1, cantidadDespues - cantidadAntes);
        }
        [TestMethod]
        public void SePuedeEjecutarModificacionCategoriaSiSeEstaLogueado()
        {
            int nuevaCategoria = categoriaGUI.AltaCategoria("algunaCategoria");
            categoriaGUI.ModificarCategoria(nuevaCategoria, "modAlgunaCat");
            Assert.AreEqual("modAlgunaCat", sesion.BuscarCategoriaPorId(nuevaCategoria).Nombre);
        }
    }
}
