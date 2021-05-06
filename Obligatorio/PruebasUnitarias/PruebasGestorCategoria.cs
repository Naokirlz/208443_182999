using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasGestorCategoria
    {
        private GestorCategorias Gestor = new GestorCategorias();

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMenor3Caracteres()
        {
            Gestor.Alta("12");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMayor15Caracteres()
        {
            Gestor.Alta("1234512345123451");
        }

        [TestMethod]
        public void SeGuardaCorrectamenteElNombre()
        {

            Categoria NuevaCategoria = Gestor.Alta("ElNombre");
            string nombre = "ElNombre";
            Assert.AreEqual(nombre, NuevaCategoria.Nombre);
        }

        [TestMethod]
        public void SeAsignaElIdAutoincremental()
        {
            Categoria UnaCategoria = Gestor.Alta("Incremental");
            Categoria OtraCategoria = Gestor.Alta("Incremental2");
            int diferencia = OtraCategoria.Id - UnaCategoria.Id;
            Assert.AreEqual(1, diferencia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedeCrearCategoriaRepetida()
        {
            Categoria UnaCategoria = Gestor.Alta("CateRepetida");
            Categoria RepetidaCategoria = Gestor.Alta("CateRepetida");
        }

        [TestMethod]
        public void BuscarUnaCategoriaExistente()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCategoria");
            int id = UnaCategoria.Id;
            Categoria Buscada = Gestor.BuscarCategoriaPorId(id);
            Assert.AreEqual(UnaCategoria, Buscada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void BuscarUnaCategoriaNoExistente()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscOtraCat");
            int id = UnaCategoria.Id + 1;
            Categoria Buscada = Gestor.BuscarCategoriaPorId(id);
        }

        [TestMethod]
        public void ModificarUnaCategoriaExistente()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCate1");
            int id = UnaCategoria.Id;
            Assert.AreEqual(UnaCategoria.Nombre, "BuscarCate1");
            string nombreNuevo = "BuscarCate2";
            Gestor.Modificacion(id, nombreNuevo);
            Assert.AreEqual(UnaCategoria.Nombre, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoModificarUnaCategoriaNombreRepetido()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCate1");
            Categoria UnaDCategoria = Gestor.Alta("BuscarCate3");

            int id = UnaCategoria.Id;
            string nombreNuevo = "BuscarCate1";
            Gestor.Modificacion(id, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreCorto()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCate1");
            int id = UnaCategoria.Id;
            string nombreNuevo = "Bu";
            Gestor.Modificacion(id, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreLargo()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCate4");
            int id = UnaCategoria.Id;
            string nombreNuevo = "1234567891234567";
            Gestor.Modificacion(id, nombreNuevo);
        }


        [TestMethod]
        public void SePuedenVerTodasLasCategorias()
        {
            GestorCategorias Gestor2 = new GestorCategorias();
            Categoria categoria1 = Gestor2.Alta("Categoria1");
            Categoria categoria2 = Gestor2.Alta("Categoria2");
            Categoria categoria3 = Gestor2.Alta("Categoria3");

            bool estaCat1 = false;
            bool estaCat2 = false;
            bool estaCat3 = false;
            bool categoriaDif = false;


            IEnumerable<Categoria> Lista = Gestor2.ObtenerTodasLasCategorias();

            foreach (Categoria categoria in Lista)
            {

                if (categoria.Nombre == categoria1.Nombre && categoria.Id == categoria1.Id) { estaCat1 = true; }
                else if (categoria.Nombre == categoria2.Nombre && categoria.Id == categoria2.Id) { estaCat2 = true; }
                else if (categoria.Nombre == categoria3.Nombre && categoria.Id == categoria3.Id) { estaCat3 = true; }
                else { categoriaDif = true; }

            }

            Assert.IsTrue(estaCat1 && estaCat2 && estaCat3 && !categoriaDif);

        }

        [TestMethod]
        public void NoSeEnviaLaListaOriginalPorParametro()
        {
            GestorCategorias Gestor2 = new GestorCategorias();
            Categoria categoria1 = Gestor2.Alta("Categoria1");

            IEnumerable<Categoria> Lista = Gestor2.ObtenerTodasLasCategorias();
            int id = 0;

            foreach (Categoria cat in Lista)
            {
                cat.Nombre = "modificoObjeto";
                id = cat.Id;
            }

            Categoria posCero = Gestor2.BuscarCategoriaPorId(id);
            Assert.AreNotEqual("modificoObjeto", posCero.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void EliminarElementoNoExistente()
        {
            GestorCategorias Gestor3 = new GestorCategorias();
            Categoria categoria1 = Gestor3.Alta("Categoria1");
            int id = categoria1.Id + 2;
            Gestor3.Baja(id);

        }

        [TestMethod]
        public void PruebaEliminarCategoria()
        {
            GestorCategorias Gestor4 = new GestorCategorias();
            Categoria categoria1 = Gestor4.Alta("Categoria1");
            int id = categoria1.Id;
            Gestor4.Baja(id);
            IEnumerable<Categoria> lista = Gestor4.ObtenerTodasLasCategorias();
            bool esta = false;
            foreach (Categoria cat in lista)
            {
                if (cat.Id == categoria1.Id) esta = true;
            }
            Assert.IsFalse(esta);
        }

        [TestMethod]
        public void ElMetodoToStringDevuelveElNombre()
        {
            Categoria categoria = Gestor.Alta("Categoria10");
            string nombre = categoria.ToString();
            Assert.AreEqual("Categoria10", nombre);
        }
    }
}
