using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Utilidades;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasFuente
    {

        private FuenteArchivo fuenteArchivo;
        private FuenteLocal fuenteLocal;

        [TestInitialize]
        public void TestInitialize()
        {

            fuenteArchivo = new FuenteArchivo();
            fuenteLocal = new FuenteLocal();

        }

        [TestMethod]
        public void CrearDataBreaches()
        {

            string texto = "aaaaa '\n' bbbb";
            fuenteLocal.CrearDatabreach(texto);

            Assert.AreEqual(1, 1);

        }

        //[TestMethod]
        //public void SePuedeLeerUnaContrasenaVulnerableDeUnFuenteLocal()
        //{

        //    string contraseniaVulnerable = "secreto";
        //    fuenteLocal.CrearDatabreach(contraseniaVulnerable);

        //}


    }

}
