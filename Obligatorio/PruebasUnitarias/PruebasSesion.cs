using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Excepciones;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasSesion
    {
        Sesion sesionPrueba;
        FuenteLocal Fuente;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;


        [TestInitialize]
        public void InicializarPruebas()
        {
            sesionPrueba = Sesion.Singleton;
            Fuente = new FuenteLocal();

            this.nuevoTarjeta = new TarjetaCredito()
            {
                Categoria = new Categoria("Fake"),
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
                Password = "dalevo111!!!",
                Categoria = new Categoria("Fake"),
                Notas = "Sin"
            };

            sesionPrueba.GestorTarjetaCredito.Alta(nuevoTarjeta);
            sesionPrueba.GestorContrasenia.Alta(pruebaContrasenia);
            sesionPrueba.MisFuentes.Add(Fuente);
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("dalevo111!!!");
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesionPrueba.GestorContrasenia = new GestorContrasenias();
            sesionPrueba.GestorTarjetaCredito = new GestorTarjetaCredito();
            sesionPrueba.MisFuentes = new List<IFuente>();
        }

        [TestMethod]
        public void InicioSesionCorrecto()
        {
            sesionPrueba.GuardarPrimerPassword("secreto");
            Assert.IsTrue(sesionPrueba.Login("secreto"));
        }

        [TestMethod]
        public void LaSesionGuardaLaPrimerContraseniaQueSeIngresa()
        {
            string primerPassword = "nuevoPasswrod";
            sesionPrueba.GuardarPrimerPassword(primerPassword);
            Assert.IsTrue(sesionPrueba.Login("nuevoPasswrod"));
        }

        [TestMethod]
        public void NoSePuedeIniciarSesionSinIngresarElPrimerPassword()
        {
            Assert.IsFalse(sesionPrueba.Login(""));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeGuardarElPasswordMaestroMenorA5Caracteres()
        {
            sesionPrueba.GuardarPrimerPassword("aaaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeGuardarElPasswordMaestroMayorA25Caracteres()
        {
            sesionPrueba.GuardarPrimerPassword("12345123451234512345123451");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void SeDebeTrimarElPasswordMaestro()
        {
            sesionPrueba.GuardarPrimerPassword("aaaa       ");
        }

        [TestMethod]
        public void AgregarContraseniaOTarjetaVulnerableAFuente()
        {
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("admin123");
            int cantidadVecesEncontrada = sesionPrueba.MisFuentes[0].BuscarPasswordOContraseniaEnFuente("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 1);
        }

        [TestMethod]
        public void Agregar2VecesLaMismaContraseniaOTarjetaVulnerableAFuente()
        {
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("admin123");
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("admin123");
            int cantidadVecesEncontrada = sesionPrueba.MisFuentes[0].BuscarPasswordOContraseniaEnFuente("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 2);

        }


        [TestMethod]
        public void EncuentraContraseniaVulnerableEnFuente()
        {
       
            sesionPrueba.ContraseniasVulnerables(Fuente);
            pruebaContrasenia = sesionPrueba.GestorContrasenia.Buscar(pruebaContrasenia.Id);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesUnaContraseniaVulnerableEnUnaFuente()
        {
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("dalevo111!!!");
           
            sesionPrueba.ContraseniasVulnerables(Fuente);
            pruebaContrasenia = sesionPrueba.GestorContrasenia.Buscar(pruebaContrasenia.Id);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 2);
           
           
        }

        [TestMethod]
        public void AciertaDosVecesLasContraseniasVulnerables()
        {

            List<Contrasenia> contrasenias = sesionPrueba.ContraseniasVulnerables(Fuente);
            List<Contrasenia> contrasenias2 = sesionPrueba.ContraseniasVulnerables(Fuente);
            Assert.AreEqual(contrasenias.Count(), contrasenias2.Count());

        }


        [TestMethod]
        public void EncuentraTarjetaVulnerableEnFuente()
        {
            
            sesionPrueba.TarjetasCreditoVulnerables(Fuente);
            nuevoTarjeta = sesionPrueba.GestorTarjetaCredito.Buscar(nuevoTarjeta);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesTarjetaVulnerableEnUnaFuente()
        {
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");

            sesionPrueba.TarjetasCreditoVulnerables(Fuente);
            nuevoTarjeta = sesionPrueba.GestorTarjetaCredito.Buscar(nuevoTarjeta);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 2);

        }

        [TestMethod]
        public void SiApareceMuchasVecesVulnerableDevuelveUnSoloObjeto()
        {

            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");

            List<TarjetaCredito> tarjetasVulnerables = sesionPrueba.TarjetasCreditoVulnerables(Fuente);

            Assert.AreEqual(1, tarjetasVulnerables.Count());

        }

    }
}
