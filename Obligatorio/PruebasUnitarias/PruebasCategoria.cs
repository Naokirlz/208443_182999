using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Negocio;
using Negocio.Excepciones;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasCategoria
    {
        //private Categoria NuevaCategoria;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    this.NuevaCategoria = new Categoria("hola" + con);
        //    ContadorInt++;
        //}

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMenor3Caracteres()
        {
            Categoria UnaCategoria = new Categoria("12");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMayor15Caracteres()
        {
            Categoria UnaCategoria = new Categoria("1234512345123451");
        }

        [TestMethod]
        public void SeGuardaCorrectamenteElNombre()
        {
            Categoria NuevaCategoria = new Categoria("ElNombre");
            string nombre = "ElNombre";
            Assert.AreEqual(nombre, NuevaCategoria.Nombre);
        }

        [TestMethod]
        public void SeAsignaElIdAutoincremental()
        {
            Categoria UnaCategoria = new Categoria("Incremental");
            Categoria OtraCategoria = new Categoria("Incremental2");
            int diferencia = OtraCategoria.Id - UnaCategoria.Id;
            Assert.AreEqual(1, diferencia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedeCrearCategoriaRepetida()
        {
            Categoria UnaCategoria = new Categoria("CateRepetida");
            Categoria RepetidaCategoria = new Categoria("CateRepetida");
        }

        [TestMethod]
        public void BuscarUnaCategoriaExistente()
        {
            Categoria UnaCategoria = new Categoria("BuscarCategoria");
            int id = UnaCategoria.Id;
            Categoria Buscada = Categoria.BuscarCategoria(id);
            Assert.AreEqual(UnaCategoria, Buscada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void BuscarUnaCategoriaNoExistente()
        {
            Categoria UnaCategoria = new Categoria("BuscOtraCat");
            int id = UnaCategoria.Id + 1;
            Categoria Buscada = Categoria.BuscarCategoria(id);
        }

        [TestMethod]
        public void ModificarUnaCategoriaExistente()
        {
            Categoria UnaCategoria = new Categoria("BuscarCate1");
            int id = UnaCategoria.Id;
            Assert.AreEqual(UnaCategoria.Nombre, "BuscarCate1");
            string nombreNuevo = "BuscarCate2";
            Categoria.ModificarCategoria(id, nombreNuevo);
            Assert.AreEqual(UnaCategoria.Nombre, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoModificarUnaCategoriaNombreRepetido()
        {
            Categoria UnaCategoria = new Categoria("BuscarCate1");
            Categoria UnaDCategoria = new Categoria("BuscarCate3");
            int id = UnaCategoria.Id;
            string nombreNuevo = "BuscarCate1";
            Categoria.ModificarCategoria(id, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreCorto()
        {
            Categoria UnaCategoria = new Categoria("BuscarCate1");
            int id = UnaCategoria.Id;
            string nombreNuevo = "Bu";
            Categoria.ModificarCategoria(id, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreLargo()
        {
            Categoria UnaCategoria = new Categoria("BuscarCate1");
            int id = UnaCategoria.Id;
            string nombreNuevo = "1234567891234567";
            Categoria.ModificarCategoria(id, nombreNuevo);
        }
    }
}
