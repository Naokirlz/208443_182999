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
        Sesion sesionTrucha;
        FuenteLocal Fuente;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;


        [TestInitialize]
        public void InicializarPruebas()
        {
            sesionTrucha = Sesion.Singleton;
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

            sesionTrucha.GestorTarjetaCredito.Alta(nuevoTarjeta);
            sesionTrucha.GestorContrasenia.Alta(pruebaContrasenia);
            sesionTrucha.MisFuentes.Add(Fuente);
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesionTrucha.GestorContrasenia = new GestorContrasenias();
            sesionTrucha.GestorTarjetaCredito = new GestorTarjetaCredito();
            sesionTrucha.MisFuentes = new List<IFuente>();
           
            
    }

        [TestMethod]
        public void EncuentraContraseniaVulnerableEnFuente()
        {
            sesionTrucha.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("dalevo111!!!");

            List<Contrasenia> contraseniasVulnerablesEncontradas = sesionTrucha.ContraseniasVulnerables(Fuente);
            pruebaContrasenia = sesionTrucha.GestorContrasenia.Buscar(pruebaContrasenia.Id);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesContraseniaVulnerableEnFuente()
        {
            sesionTrucha.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("dalevo111!!!");
            sesionTrucha.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("dalevo111!!!");

            List<Contrasenia> contraseniasVulnerablesEncontradas = sesionTrucha.ContraseniasVulnerables(Fuente);
            pruebaContrasenia = sesionTrucha.GestorContrasenia.Buscar(pruebaContrasenia.Id);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 2);

        }


        [TestMethod]
        public void EncuentraTarjetaVulnerableEnFuente()
        {
            sesionTrucha.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");

            List<TarjetaCredito> tarjetasVulnerablesEncontradas = sesionTrucha.TarjetasCreditoVulnerables(Fuente);
            nuevoTarjeta = sesionTrucha.GestorTarjetaCredito.Buscar(nuevoTarjeta);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesTarjetaVulnerableEnFuente()
        {
            sesionTrucha.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");
            sesionTrucha.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");

            List<TarjetaCredito> tarjetasVulnerablesEncontradas = sesionTrucha.TarjetasCreditoVulnerables(Fuente);
            nuevoTarjeta = sesionTrucha.GestorTarjetaCredito.Buscar(nuevoTarjeta);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 2);

        }


    }
}
