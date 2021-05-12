using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Utilidades;
using System.Linq;
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
            Assert.AreEqual("ElNombre", Gestor.BuscarCategoriaPorId(idCategoria).Nombre);
        }

        [TestMethod]
        public void SeAsignaElIdAutoincremental()
        {
            int idUnaCategoria = Gestor.Alta("Incremental");
            int idOtraCategoria = Gestor.Alta("Incremental2");
            Assert.AreEqual(1, idOtraCategoria - idUnaCategoria);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedeCrearCategoriaRepetida()
        {
            Gestor.Alta("CateRepetida");
            Gestor.Alta("CateRepetida");
        }

        [TestMethod]
        public void BuscarUnaCategoriaExistente()
        {
            int idUnaCategoria = Gestor.Alta("BuscarCategoria");
            Categoria Buscada = Gestor.BuscarCategoriaPorId(idUnaCategoria);
            Assert.AreEqual("BuscarCategoria", Buscada.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void BuscarUnaCategoriaNoExistente()
        {
            Gestor.BuscarCategoriaPorId(-200);
        }

        [TestMethod]
        public void ModificarUnaCategoriaExistente()
        {
            int idUnaCategoria = Gestor.Alta("UnaCategoria");
            Gestor.ModificarCategoria(idUnaCategoria, "nombre Nuevo");
            Assert.AreEqual("nombre Nuevo", Gestor.BuscarCategoriaPorId(idUnaCategoria).Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoModificarUnaCategoriaNombreRepetido()
        {
            Gestor.Alta("UnaCategoria");
            int idOtraCategoria = Gestor.Alta("OtraCategoria");
            Gestor.ModificarCategoria(idOtraCategoria, "UnaCategoria");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreCorto()
        {
            int idUnaCategoria = Gestor.Alta("UnaCategoria");
            Gestor.ModificarCategoria(idUnaCategoria, "Bu");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoModificarUnaCategoriaNombreLargo()
        {
            int idUnaCategoria = Gestor.Alta("UnaCategoria");
            Gestor.ModificarCategoria(idUnaCategoria, "1234567891234567");
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
            Gestor.Baja(-200);
        }

        [TestMethod]
        public void PruebaEliminarCategoria()
        {
            int idCategoriaAlta = Gestor.Alta("CategoriaAlta");
            int cantidadAntes = Gestor.ObtenerTodas().Count();
            Gestor.Baja(idCategoriaAlta);
            int cantidadDespues = Gestor.ObtenerTodas().Count();
            Assert.AreEqual(1, cantidadAntes - cantidadDespues);
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
