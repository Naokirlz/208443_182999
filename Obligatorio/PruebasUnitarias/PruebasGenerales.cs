using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using System;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasGenerales
    {
        private Sesion sis = Sesion.Singleton;
        

        [TestInitialize]
        public void TestInitialize()
        {
            //this.Password = "secreto";
            //this.Gestor = new GestorCategorias(Password);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //this.Password = null;
            //this.Gestor = null;
        }

        [TestMethod]
        public void SePuedeAccederAlSistemaConPasswordCorrecto()
        {
            bool acceso = this.sis.Login("secreto");
            Assert.IsTrue(acceso);
        }
    }
}
