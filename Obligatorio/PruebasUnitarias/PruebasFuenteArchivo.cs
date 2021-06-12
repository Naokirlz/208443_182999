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
    public class PruebasFuenteArchivo
    {

        private FuenteArchivo fuente;

        [TestInitialize]
        public void TestInitialize()
        {

            fuente = new FuenteArchivo();

        }


        [TestMethod]
        public void SePuedeLeerUnaContrasenaVulnerableDeUnArchivo()
        {

         string rutaViviendas = AppDomain.CurrentDomain.BaseDirectory + "Archivos\\Barrios.txt";
         string rutaViviendas2 = AppDomain.CurrentDomain.BaseDirectory;


         Assert.AreEqual("ruta", rutaViviendas);

        }


    }

}
