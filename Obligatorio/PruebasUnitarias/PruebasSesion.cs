using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
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

        Sesion instancia = Sesion.Singleton;
                
        TarjetaCredito nuevoTarjeta = new TarjetaCredito()
        {
            Categoria = new Categoria("Fake"),
            Nombre = "PruebaNombre",
            Tipo = "PruebaTipo",
            Numero = "1234123412341234",
            Codigo = "123",
            Vencimiento = DateTime.Now,
            Nota = "Nota Opcional"
        };

        

        [TestMethod]
        public void EncuentraTarjetaVulnerableEnFuente()
        {
            instancia.GestorTarjetaCredito.Alta(nuevoTarjeta);
            FuenteSimulada Fuente = new FuenteSimulada();
            Fuente.ContraseniasYTarjetasVulnerables.Add("1234123412341234");
            instancia.MisFuentes.Add(Fuente);

            List<string> tarjetasVulnerablesEncontradas = instancia.TarjetasCreditoVulnerables(Fuente);

            Assert.AreEqual(tarjetasVulnerablesEncontradas[0], "1234123412341234");

        }


    }
}
