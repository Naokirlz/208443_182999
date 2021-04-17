using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Negocio;
using Negocio.Excepciones;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasCategoria
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMenor3Caracteres()
        {
            Categoria nuevaCategoria = new Categoria("12");

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMayor15Caracteres()
        {
            Categoria nuevaCategoria = new Categoria("1234512345123451");

        }

        [TestMethod]
        public void SeGuardaCorrectamenteElNombre()
        {
            Categoria nuevaCategoria = new Categoria("hola");
            string nombre = "hola";
            Assert.AreEqual(nombre, nuevaCategoria.Nombre);
        }

        [TestMethod]
        public void SeAsignaElId()
        {
            Categoria nuevaCategoria = new Categoria("hola");
            int id = 1;
            Assert.AreEqual(id, nuevaCategoria.Id);
        }

        [TestMethod]
        public void SeAsignaElIdAutoincremental()
        {
            Categoria nuevaCategoria = new Categoria("hola");
            Categoria otraCategoria = new Categoria("hola");
            int diferencia = otraCategoria.Id - nuevaCategoria.Id;
            Assert.AreEqual(1, diferencia);
        }
    }
}
