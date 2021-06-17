using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.InterfacesGUI;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasVulnerabilidadesGUI
    {
        private IVulnerabilidades vulnerabilidadesGUI;
        private Sesion sesion;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;


        [TestInitialize]
        public void InicializarPruebas()
        {
            vulnerabilidadesGUI = new VulnerabilidadesGUI();
            sesion = Sesion.ObtenerInstancia();

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

            this.pruebaContrasenia = new Contrasenia()
            {
                Sitio = "deremate.com",
                Usuario = "fedex",
                Password = new Password("dalevo111!!!"),
                Categoria = nuevaCategoriaPrueba,
                Notas = "Sin"
            };

            sesion.AltaTarjetaCredito(nuevoTarjeta);
            sesion.AltaContrasenia(pruebaContrasenia);
            FuenteLocal fuente = new FuenteLocal();
            vulnerabilidadesGUI.CargarDataBreach(fuente, "dalevo111!!!\n1234123412341234");
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesion.VaciarDatosPrueba();
        }

        [TestMethod]
        public void SePuedeEjecutarBuscarContraseniaEstandoLogueado()
        {
            int id = sesion.ObtenerTodasLasContrasenias().First().ContraseniaId;
            Contrasenia buscada = vulnerabilidadesGUI.BuscarContrasenia(id);
            Assert.IsNotNull(buscada);
        }


        [TestMethod]
        public void EncuentraContraseniaVulnerableEnFuente()
        {

            vulnerabilidadesGUI.ContraseniasVulnerables();
            Contrasenia vulnerable = vulnerabilidadesGUI.BuscarContrasenia(pruebaContrasenia.ContraseniaId);
            Assert.AreEqual(1, vulnerable.CantidadVecesEncontradaVulnerable);

        }

        [TestMethod]
        public void Encuentra2VecesUnaContraseniaVulnerableEnUnaFuente()
        {
            FuenteLocal fuente = new FuenteLocal();
            vulnerabilidadesGUI.CargarDataBreach(fuente, "dalevo111!!!");
            vulnerabilidadesGUI.ContraseniasVulnerables();
            pruebaContrasenia = vulnerabilidadesGUI.BuscarContrasenia(pruebaContrasenia.ContraseniaId);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 2);
        }

        [TestMethod]
        public void AciertaDosVecesLasContraseniasVulnerables()
        {

            IEnumerable<Contrasenia> contrasenias = vulnerabilidadesGUI.ContraseniasVulnerables();
            IEnumerable<Contrasenia> contrasenias2 = vulnerabilidadesGUI.ContraseniasVulnerables();
            Assert.AreEqual(contrasenias.Count(), contrasenias2.Count());

        }

        [TestMethod]
        public void EncuentraTarjetaVulnerableEnFuente()
        {

            vulnerabilidadesGUI.TarjetasCreditoVulnerables();
            nuevoTarjeta = sesion.BuscarTarjeta(nuevoTarjeta.Id);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesTarjetaVulnerableEnUnaFuente()
        {
            FuenteLocal fuente = new FuenteLocal();
            vulnerabilidadesGUI.CargarDataBreach(fuente, "1234123412341234");
            vulnerabilidadesGUI.TarjetasCreditoVulnerables();
            nuevoTarjeta = sesion.BuscarTarjeta(nuevoTarjeta.Id);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 2);

        }

        [TestMethod]
        public void SiApareceMuchasVecesVulnerableDevuelveUnSoloObjeto()
        {
            FuenteLocal fuente = new FuenteLocal();
            vulnerabilidadesGUI.CargarDataBreach(fuente, "1234123412341234");
            vulnerabilidadesGUI.CargarDataBreach(fuente, "1234123412341234");
            IEnumerable<TarjetaCredito> tarjetasVulnerables = vulnerabilidadesGUI.TarjetasCreditoVulnerables();
            Assert.AreEqual(1, tarjetasVulnerables.Count());

        }

        [TestMethod]
        public void SePuedeGenerarUnHistorial()
        {
            int historial = vulnerabilidadesGUI.ConsultarVulnerabilidades();
            Assert.IsNotNull(historial);
        }

        [TestMethod]
        public void ElHistorialDevulveContraseniasVulnerables()
        {
            int historial = vulnerabilidadesGUI.ConsultarVulnerabilidades();
            IEnumerable<HistorialContrasenia> contraseniaVulnerable = vulnerabilidadesGUI.DevolverContraseniasVulnerables(historial);

            Assert.AreEqual(1, contraseniaVulnerable.Count());
            Assert.AreEqual("dalevo111!!!", contraseniaVulnerable.First().Clave);
            Assert.AreEqual(pruebaContrasenia.ContraseniaId, contraseniaVulnerable.First().ContraseniaId);
        }

        [TestMethod]
        public void ElHistorialDevulveTarjetasVulnerables()
        {
            int historial = vulnerabilidadesGUI.ConsultarVulnerabilidades();
            IEnumerable<HistorialTarjetas> tarjetasVulnerable = vulnerabilidadesGUI.DevolverTarjetasVulnerables(historial);

            Assert.AreEqual(1, tarjetasVulnerable.Count());
            Assert.AreEqual("1234123412341234", tarjetasVulnerable.First().NumeroTarjeta);
        }

        [TestMethod]
        public void SeDevulvenHistoriales()
        {
            int historial = vulnerabilidadesGUI.ConsultarVulnerabilidades();
            int historial2 = vulnerabilidadesGUI.ConsultarVulnerabilidades();
            IEnumerable<Historial> historiales = vulnerabilidadesGUI.ObtenerTodasLosHistoriales();

            Assert.AreEqual(2, historiales.Count());
        }
        [TestMethod]
        public void SePuedeEjecutarMostrarPasswordEstandoLogueado()
        {
            string password = vulnerabilidadesGUI.MostrarPassword(pruebaContrasenia);
            Assert.AreEqual(pruebaContrasenia.Password.Clave, password);
        }
    }
}
