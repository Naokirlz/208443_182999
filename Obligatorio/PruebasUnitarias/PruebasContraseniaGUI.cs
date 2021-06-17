using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.InterfacesGUI;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasContraseniaGUI
    {
        private IContrasenia contraseniasGUI;
        private Contrasenia pruebaContrasenia;
        private Sesion sesion;
        [TestInitialize]
        public void InicializarPruebas()
        {
            contraseniasGUI = new ContraseniaGUI();
            sesion = Sesion.ObtenerInstancia();

            sesion.GuardarPrimerPassword("secreto");
            sesion.Login("secreto");
            int id = sesion.AltaCategoria("Cosas");
            Categoria nuevaCategoriaPrueba = sesion.BuscarCategoriaPorId(id);

            this.pruebaContrasenia = new Contrasenia()
            {
                Sitio = "deremate.com",
                Usuario = "fedex",
                Password = new Password("dalevo111!!!"),
                Categoria = nuevaCategoriaPrueba,
                Notas = "Sin"
            };

            contraseniasGUI.AltaContrasenia(pruebaContrasenia);
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesion.VaciarDatosPrueba();
        }
        [TestMethod]
        public void SePuedeEjecutarAltaContraseniaEstandoLogueado()
        {
            int cantidadAntes = contraseniasGUI.ObtenerTodasLasContrasenias().Count();
            int id = sesion.AltaCategoria("fake");
            Categoria nuevaCat = sesion.BuscarCategoriaPorId(id);

            Contrasenia contraseniaPrueba = new Contrasenia()
            {
                Sitio = "deremate.com.ar",
                Usuario = "fedexAlta",
                Password = new Password("dale%%vo111!!!"),
                Categoria = nuevaCat,
                Notas = "Sin"
            };

            contraseniasGUI.AltaContrasenia(contraseniaPrueba);
            Assert.AreEqual(1, contraseniasGUI.ObtenerTodasLasContrasenias().Count() - cantidadAntes);
        }
        [TestMethod]
        public void SePuedeEjecutarBajaContraseniaEstandoLogueado()
        {
            int id = sesion.AltaCategoria("fake");
            Categoria nuevaCat = sesion.BuscarCategoriaPorId(id);

            Contrasenia contraseniaPrueba = new Contrasenia()
            {
                Sitio = "deremate.com.ar",
                Usuario = "fedexAlta",
                Password = new Password("dale%%vo111!!!"),
                Categoria = nuevaCat,
                Notas = "Sin"
            };

            int idCon = contraseniasGUI.AltaContrasenia(contraseniaPrueba);
            int cantidadAntes = contraseniasGUI.ObtenerTodasLasContrasenias().Count();
            contraseniasGUI.BajaContrasenia(idCon);
            Assert.AreEqual(1, cantidadAntes - contraseniasGUI.ObtenerTodasLasContrasenias().Count());
        }
        [TestMethod]
        public void SeGeneranGrupos()
        {
            Contrasenia nuevaCon = new Contrasenia()
            {
                Sitio = pruebaContrasenia.Sitio,
                Categoria = pruebaContrasenia.Categoria,
                Password = new Password("1234567"),
                Usuario = "ussu1"
            };
            contraseniasGUI.AltaContrasenia(nuevaCon);

            Contrasenia nuevaCon2 = new Contrasenia()
            {
                Sitio = pruebaContrasenia.Sitio,
                Categoria = pruebaContrasenia.Categoria,
                Password = new Password("12345678"),
                Usuario = "ussu2"
            };
            contraseniasGUI.AltaContrasenia(nuevaCon2);

            Contrasenia nuevaCon3 = new Contrasenia()
            {
                Sitio = pruebaContrasenia.Sitio,
                Categoria = pruebaContrasenia.Categoria,
                Password = new Password("aaaaaaaaaaaaaaa"),
                Usuario = "ussu3"
            };
            contraseniasGUI.AltaContrasenia(nuevaCon3);

            Contrasenia nuevaCon4 = new Contrasenia()
            {
                Sitio = pruebaContrasenia.Sitio,
                Categoria = pruebaContrasenia.Categoria,
                Password = new Password("AAAAAAaAAAAAAAA"),
                Usuario = "ussu4"
            };
            contraseniasGUI.AltaContrasenia(nuevaCon4);

            Contrasenia nuevaCon5 = new Contrasenia()
            {
                Sitio = pruebaContrasenia.Sitio,
                Categoria = pruebaContrasenia.Categoria,
                Password = new Password(" AAAA1@ AAAAAAA"),
                Usuario = "ussu5"
            };
            contraseniasGUI.AltaContrasenia(nuevaCon5);

            Contrasenia nuevaCon6 = new Contrasenia()
            {
                Sitio = pruebaContrasenia.Sitio,
                Categoria = pruebaContrasenia.Categoria,
                Password = new Password("AAAAAAaAAAA$AA1"),
                Usuario = "ussu6"
            };
            contraseniasGUI.AltaContrasenia(nuevaCon6);

            List<Grupo> grupos = contraseniasGUI.GenerarGrupos().ToList();
            Assert.IsNotNull(grupos);
        }
        [TestMethod]
        public void SePuedeEjecutarModificarContraseniaEstandoLogueado()
        {

            Contrasenia anterior = contraseniasGUI.ObtenerTodasLasContrasenias().First();
            string sitioViejo = anterior.Sitio;
            int idCat = sesion.AltaCategoria("Fake");
            Categoria categorianueva = sesion.BuscarCategoriaPorId(idCat);

            Contrasenia contraseniaModificar = new Contrasenia()
            {
                Sitio = "sitio nuevo",
                Usuario = "fedexAlta",
                Password = new Password("dale%%vo111!!!"),
                Categoria = categorianueva,
                Notas = "Sin",
                ContraseniaId = anterior.ContraseniaId
            };

            contraseniasGUI.ModificarContrasenia(contraseniaModificar);

            Contrasenia nueva = sesion.BuscarContrasenia(anterior.ContraseniaId);
            string sitioNuevo = nueva.Sitio;

            Assert.AreNotEqual(sitioViejo, sitioNuevo);
        }
        [TestMethod]
        public void SePuedeEjecutarMostrarPasswordEstandoLogueado()
        {
            string password = contraseniasGUI.MostrarPassword(pruebaContrasenia);
            Assert.AreEqual(pruebaContrasenia.Password.Clave, password);
        }
        [TestMethod]
        public void SePuedenObtenerTodasLasCategorias()
        {
            int categorias = contraseniasGUI.ObtenerTodasLasCategorias().Count(); ;
            Assert.IsTrue(categorias > 0);
        }
        [TestMethod]
        public void LaSesionMeDevuelveSiElPasswordEsRepetido()
        {
            int id = sesion.AltaCategoria("Mas Cosas");
            Categoria nuevaCategoriaPrueba = sesion.BuscarCategoriaPorId(id);
            Contrasenia pruebaContrasenia2 = new Contrasenia()
            {
                Sitio = "deremate.com",
                Usuario = "deremate",
                Password = new Password("dalevo111!!!"),
                Categoria = nuevaCategoriaPrueba,
                Notas = "Sin"
            };

            contraseniasGUI.AltaContrasenia(pruebaContrasenia2);

            string password = "dalevo111!!!";

            int vecesRepetido = contraseniasGUI.VerificarCatidadVecesPasswordRepetido(password);
            Assert.AreEqual(2, vecesRepetido);
        }
        [TestMethod]
        public void LaSesionMeDevuelveElColorDeUnPassword()
        {
            string password = "HolaSecretoPassword";
            string fortaleza = contraseniasGUI.VerificarFortalezaPassword(password);
            Assert.AreEqual("VERDE_CLARO", fortaleza);
        }
        [TestMethod]
        public void AgregarContraseniaOTarjetaVulnerableAFuente()
        {
            FuenteLocal fuente2 = new FuenteLocal();
            sesion.CargarDataBreach(fuente2, "admin123");
            int cantidadVecesEncontrada = contraseniasGUI.VerificarPasswordFiltrado("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 1);
        }

        [TestMethod]
        public void Agregar2VecesLaMismaContraseniaOTarjetaVulnerableAFuente()
        {
            FuenteLocal fuente = new FuenteLocal();
            sesion.CargarDataBreach(fuente, "admin123");
            sesion.CargarDataBreach(fuente, "admin123");
            int cantidadVecesEncontrada = contraseniasGUI.VerificarPasswordFiltrado("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 2);
        }
    }
}
