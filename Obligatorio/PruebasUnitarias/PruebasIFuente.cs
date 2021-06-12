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
    public class PruebasIFuente
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
        public void SePuedeLeerUnaContrasenaVulnerableDeUnFuenteLocal()
        {

            string contraseniaVulnerable = "secreto";
            fuenteLocal.CrearDatabreach(contraseniaVulnerable);

        }


    }

}
