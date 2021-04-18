using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasGenerales
    {
        private string Password;
        private GestorCategorias Gestor;

        [TestInitialize]
        public void TestInitialize()
        {
            this.Password = "secreto";
            this.Gestor = new GestorCategorias(Password);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.Password = null;
            this.Gestor = null;
        }

        [TestMethod]
        public void SePuedeAccederAlSistemaConPasswordCorrecto()
        {
            bool acceso = this.Gestor.Login(this.Password);
            Assert.IsTrue(acceso);
        }
    }
}
