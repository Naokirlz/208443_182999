using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.InterfacesGUI;
using Negocio.TarjetaCreditos;
using System;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasTarjetasGUI
    {
        private ITarjetaCredito tarjetaCreditoGUI;
        private TarjetaCredito nuevoTarjeta;
        private Sesion sesion;


        [TestInitialize]
        public void InicializarPruebas()
        {
            sesion = Sesion.ObtenerInstancia();
            sesion.VaciarDatosPrueba();
            tarjetaCreditoGUI = new TarjetaCreditoGUI();

            sesion.GuardarPrimerPassword("secreto");
            sesion.Login("secreto");
            int id = sesion.AltaCategoria("Cosas");
            Categoria nuevaCategoriaPrueba = sesion.BuscarCategoriaPorId(id);

            this.nuevoTarjeta = new TarjetaCredito()
            {
                Categoria = nuevaCategoriaPrueba,
                Nombre = "PruebaNombre",
                Tipo = "PruebaTipo",
                Numero = "1234123412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",

            };

            tarjetaCreditoGUI.AltaTarjetaCredito(nuevoTarjeta);
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesion.VaciarDatosPrueba();
        }
        [TestMethod]
        public void SePuedeEjecutarObtenerTodasLasCategoria()
        {
            int cantidad = tarjetaCreditoGUI.ObtenerTodasLasCategorias().Count();
            Assert.IsTrue(cantidad > 0);
        }
        [TestMethod]
        public void SePuedeEjecutarAltaTarjetaEstandoLogueado()
        {
            int id = sesion.AltaCategoria("fake");
            Categoria nuevaCat = sesion.BuscarCategoriaPorId(id);

            TarjetaCredito nuevoTarjetaPrueba = new TarjetaCredito()
            {
                Categoria = nuevaCat,
                Nombre = "PruebaNombre2",
                Tipo = "PruebaTipo2",
                Numero = "1234123412344444",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",

            };

            int antes = tarjetaCreditoGUI.ObtenerTodasLasTarjetas().Count();
            tarjetaCreditoGUI.AltaTarjetaCredito(nuevoTarjetaPrueba);
            int despues = tarjetaCreditoGUI.ObtenerTodasLasTarjetas().Count();
            Assert.AreEqual(1, despues - antes);
        }

        [TestMethod]
        public void SePuedeEjecutarModificarTarjetaEstandoLogueado()
        {
            int id = nuevoTarjeta.Id;
            string nombreAnterior = nuevoTarjeta.Nombre;

            int idCat = sesion.AltaCategoria("fake");
            Categoria nuevaCat = sesion.BuscarCategoriaPorId(idCat);

            TarjetaCredito modificadaTarjetaPrueba = new TarjetaCredito()
            {
                Categoria = nuevaCat,
                Nombre = "nombreModificado",
                Tipo = "PruebaTipo2",
                Numero = "1234123412344444",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",
                Id = id
            };

            tarjetaCreditoGUI.ModificarTarjeta(modificadaTarjetaPrueba);
            string nombreActual = sesion.BuscarTarjeta(nuevoTarjeta.Id).Nombre;
            Assert.AreNotEqual(nombreActual, nombreAnterior);
        }




        [TestMethod]
        public void SePuedeEjecutarObtenerTodasTarjetaEstandoLogueado()
        {
            int cantidad = tarjetaCreditoGUI.ObtenerTodasLasTarjetas().Count();
            tarjetaCreditoGUI.BajaTarjetaCredito(nuevoTarjeta.Id);
            Assert.AreEqual(1, cantidad - tarjetaCreditoGUI.ObtenerTodasLasTarjetas().Count());

        }
    }
}
