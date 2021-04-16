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




    }
}
