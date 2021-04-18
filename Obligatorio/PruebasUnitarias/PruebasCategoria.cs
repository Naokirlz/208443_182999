﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Negocio;
using Negocio.Excepciones;
using Negocio.Clases;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasCategoria
    {
        private GestorCategorias Gestor = new GestorCategorias();

       
        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMenor3Caracteres()
        {
            Gestor.Alta("12");            
            //Categoria UnaCategoria = new Categoria("12");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaCategoriaConNombreMayor15Caracteres()
        {
            Gestor.Alta("1234512345123451");
            //Categoria UnaCategoria = new Categoria("1234512345123451");
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

            //Categoria UnaCategoria = new Categoria("Incremental");
            //Categoria OtraCategoria = new Categoria("Incremental2");
            
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
            Categoria Buscada = Gestor.BuscarCategoria(id);
            Assert.AreEqual(UnaCategoria, Buscada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void BuscarUnaCategoriaNoExistente()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscOtraCat");
            int id = UnaCategoria.Id + 1;
            Categoria Buscada = Gestor.BuscarCategoria(id);
        }

        [TestMethod]
        public void ModificarUnaCategoriaExistente()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCate1");
            int id = UnaCategoria.Id;
            Assert.AreEqual(UnaCategoria.Nombre, "BuscarCate1");
            string nombreNuevo = "BuscarCate2";
            Gestor.ModificarCategoria(id, nombreNuevo);
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
            Gestor.ModificarCategoria(id, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreCorto()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCate1");
            int id = UnaCategoria.Id;
            string nombreNuevo = "Bu";
            Gestor.ModificarCategoria(id, nombreNuevo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreLargo()
        {
            Categoria UnaCategoria = Gestor.Alta("BuscarCate4");
            int id = UnaCategoria.Id;
            string nombreNuevo = "1234567891234567";
            Gestor.ModificarCategoria(id, nombreNuevo);
        }
    }
}
