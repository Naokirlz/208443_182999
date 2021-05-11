using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Utilidades;
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

            int idCategoria = Gestor.Alta("ElNombre");
            string nombre = "ElNombre";
            Assert.AreEqual(nombre, Gestor.BuscarCategoriaPorId(idCategoria).Nombre);
        }

        [TestMethod]
        public void SeAsignaElIdAutoincremental()
        {
            int UnaCategoria = Gestor.Alta("Incremental");
            int OtraCategoria = Gestor.Alta("Incremental2");
            Assert.AreEqual(1, OtraCategoria - UnaCategoria);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedeCrearCategoriaRepetida()
        {
            int UnaCategoria = Gestor.Alta("CateRepetida");
            int RepetidaCategoria = Gestor.Alta("CateRepetida");
        }

        [TestMethod]
        public void BuscarUnaCategoriaExistente()
        {
            int UnaCategoria = Gestor.Alta("BuscarCategoria");
            Categoria Buscada = Gestor.BuscarCategoriaPorId(UnaCategoria);
            Assert.AreEqual("BuscarCategoria", Buscada.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void BuscarUnaCategoriaNoExistente()
        {
            int UnaCategoria = Gestor.Alta("BuscOtraCat");
            int IdABuscar = UnaCategoria + 20;
            Categoria Buscada = Gestor.BuscarCategoriaPorId(IdABuscar);
        }

        [TestMethod]
        public void ModificarUnaCategoriaExistente()
        {
            int UnaCategoria = Gestor.Alta("BuscarCate1");
            Gestor.ModificarCategoria(UnaCategoria, "nombre Nuevo");
            Assert.AreEqual("nombre Nuevo", Gestor.BuscarCategoriaPorId(UnaCategoria).Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoModificarUnaCategoriaNombreRepetido()
        {
            int UnaCategoria = Gestor.Alta("BuscarCate1");
            int otraCategoria = Gestor.Alta("BuscarCateNuevo");
            string nombreNuevo = "BuscarCate1";
            Gestor.ModificarCategoria(otraCategoria, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreCorto()
        {
            int UnaCategoria = Gestor.Alta("BuscarCate1");
            string nombreNuevo = "Bu";
            Gestor.ModificarCategoria(UnaCategoria, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreLargo()
        {
            int UnaCategoria = Gestor.Alta("BuscarCate4");
            string nombreNuevo = "1234567891234567";
            Gestor.ModificarCategoria(UnaCategoria, nombreNuevo);
        }


        [TestMethod]
        public void SePuedenVerTodasLasCategorias()
        {
            GestorCategorias Gestor2 = new GestorCategorias();
            int categoria1 = Gestor2.Alta("Categoria1");
            int categoria2 = Gestor2.Alta("Categoria2");
            int categoria3 = Gestor2.Alta("Categoria3");

            bool estaCat1 = false;
            bool estaCat2 = false;
            bool estaCat3 = false;
            bool categoriaDif = false;


            IEnumerable<Categoria> Lista = Gestor2.ObtenerTodas();

            foreach (Categoria categoria in Lista)
            {

                if (categoria.Id == categoria1) { estaCat1 = true; }
                else if (categoria.Id == categoria2) { estaCat2 = true; }
                else if (categoria.Id == categoria3) { estaCat3 = true; }
                else { categoriaDif = true; }

            }

            Assert.IsTrue(estaCat1 && estaCat2 && estaCat3 && !categoriaDif);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void EliminarElementoNoExistente()
        {
            GestorCategorias Gestor3 = new GestorCategorias();
            int categoria1 = Gestor3.Alta("Categoria1");
            int id = categoria1 + 200;
            Gestor3.Baja(id);

        }

        [TestMethod]
        public void PruebaEliminarCategoria()
        {
            GestorCategorias Gestor4 = new GestorCategorias();
            int categoria1 = Gestor4.Alta("Categoria1");
            Gestor4.Baja(categoria1);

            IEnumerable<Categoria> lista = Gestor4.ObtenerTodas();
            bool esta = false;
            foreach (Categoria cat in lista)
            {
                if (cat.Id == categoria1) esta = true;
            }
            Assert.IsFalse(esta);
        }

        [TestMethod]
        public void ElMetodoToStringDevuelveElNombre()
        {
            int idCategoria = Gestor.Alta("Categoria10");
            Categoria buscada = Gestor.BuscarCategoriaPorId(idCategoria);
            string nombre = buscada.ToString();
            Assert.AreEqual("Categoria10", nombre);
        }
    }
}
