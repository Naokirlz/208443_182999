using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
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
            Assert.IsTrue(sesionPrueba.Login("secreto"));

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

    }
}
