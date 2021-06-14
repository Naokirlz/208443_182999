using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Excepciones;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Negocio.DataBreaches;
using static Negocio.Contrasenias.Password;

namespace PruebasUnitarias
{
    //LAS PRUEBAS SE ROMPEN PORQUE ESTAN USANDO EL REPOSITORIO ENTITY

    [TestClass]
    public class PruebasSesion
    {
        Sesion sesionPrueba;
        FuenteLocal Fuente;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;


        [TestInitialize]
        public void InicializarPruebas()
        {
            
            sesionPrueba = Sesion.ObtenerInstancia();
            
            sesionPrueba.GuardarPrimerPassword("secreto");
            sesionPrueba.Login("secreto");
            int id = sesionPrueba.AltaCategoria("Cosas");
            Categoria nuevaCategoriaPrueba = sesionPrueba.BuscarCategoriaPorId(id);

            this.nuevoTarjeta = new TarjetaCredito()
            {
                Categoria = nuevaCategoriaPrueba,
                Nombre = "PruebaNombre",
                Tipo = "PruebaTipo",
                Numero = "1234123412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",
                
            };
           
            this.pruebaContrasenia = new Contrasenia()
            {
                Sitio = "deremate.com",
                Usuario = "fedex",
                Password = new Password("dalevo111!!!"),
                Categoria = nuevaCategoriaPrueba,
                Notas = "Sin"
            };

            sesionPrueba.AltaTarjetaCredito(nuevoTarjeta);
            sesionPrueba.AltaContrasenia(pruebaContrasenia);
            sesionPrueba.CargarDataBreachLocal("dalevo111!!!\n1234123412341234");
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesionPrueba.VaciarDatosPrueba();
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (Directory.Exists(rutaDirectorio))
            {
                List<string> strFiles = Directory.GetFiles(rutaDirectorio, "*", SearchOption.AllDirectories).ToList();

                foreach (string fichero in strFiles)
                {
                    File.Delete(fichero);
                }
            }
            
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeIniciarSesionSinIngresarElPrimerPassword()
        {
            sesionPrueba.Login("");
        }


        [TestMethod]
        public void LaSesionMeDevuelveSiElPasswordSeFiltro()
        {
          
            int filtrada = 0;
            string password = "dalevo111!!!";
            filtrada = sesionPrueba.VerificarPasswordFiltrado(password);
            Assert.IsTrue(filtrada > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeCambiarElPasswordSinEstarLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.CambiarPassword("cambio password");
        }

        [TestMethod]
        public void SePuedeCambiarElPasswordEstandoLogueado()
        {
            sesionPrueba.CambiarPassword("cambio password");
            sesionPrueba.LogOut();
            sesionPrueba.Login("cambio password");
            
            int cantidadAntes = sesionPrueba.ObtenerTodasLasCategorias().Count();
            sesionPrueba.AltaCategoria("cat uno dos");
            int cantidadDespues = sesionPrueba.ObtenerTodasLasCategorias().Count();

            Assert.AreEqual(1, cantidadDespues - cantidadAntes);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarAltaCategoriaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.AltaCategoria("cat uno");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBajaCategoriaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BajaCategoria(1);
        }

        [TestMethod]
        public void SePuedeEjecutarBajaCategoriaEstandoLogueado()
        {
            int id = sesionPrueba.AltaCategoria("NuevaCategoria");
            int cantidadAntes = sesionPrueba.ObtenerTodasLasCategorias().Count();
            sesionPrueba.BajaCategoria(id);
            int cantidadDespues = sesionPrueba.ObtenerTodasLasCategorias().Count();
            Assert.AreEqual(1, cantidadAntes - cantidadDespues);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarModificarCategoriaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ModificarCategoria(1, "nuevoNombre");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBuscarCategoriaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BuscarCategoriaPorId(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarObtenerTodasLasCategoriaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ObtenerTodasLasCategorias();
        }

        [TestMethod]
        public void SePuedeEjecutarAltaCategoriaSiSeEstaLogueado()
        {
            int cantidadAntes = sesionPrueba.ObtenerTodasLasCategorias().Count();
            sesionPrueba.AltaCategoria("cat 123");
            int cantidadDespues = sesionPrueba.ObtenerTodasLasCategorias().Count();
            
            Assert.AreEqual(1, cantidadDespues - cantidadAntes) ;
        }

        [TestMethod]
        public void SePuedeEjecutarModificacionCategoriaSiSeEstaLogueado()
        {

            int nuevaCategoria = sesionPrueba.AltaCategoria("algunaCategoria");
            sesionPrueba.ModificarCategoria(nuevaCategoria, "modAlgunaCat");
            Assert.AreEqual("modAlgunaCat", sesionPrueba.BuscarCategoriaPorId(nuevaCategoria).Nombre);

        }

        [TestMethod]
        public void SePuedeEjecutarBuscarCategoriaPorIdSiSeEstaLogueado()
        {
            int nuevaCategoria = sesionPrueba.AltaCategoria("viejaCategoria");
            Categoria categoriaBuscada = sesionPrueba.BuscarCategoriaPorId(nuevaCategoria);
            Assert.IsNotNull(categoriaBuscada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarAltaTarjetaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.AltaTarjetaCredito(new TarjetaCredito());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBajaTarjetaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BajaTarjetaCredito(new TarjetaCredito().Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarModificarTarjetaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ModificarTarjeta(new TarjetaCredito());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBuscarTarjetaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BuscarTarjeta(new TarjetaCredito().Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarObtenerTodasTarjetaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ObtenerTodasLasTarjetas();
        }

        
        [TestMethod]
       public void SePuedeEjecutarAltaTarjetaEstandoLogueado()
        {
            int id = sesionPrueba.AltaCategoria("fake");
            Categoria nuevaCat = sesionPrueba.BuscarCategoriaPorId(id);

            TarjetaCredito nuevoTarjetaPrueba = new TarjetaCredito()
            {
                Categoria = nuevaCat,
                Nombre = "PruebaNombre2",
                Tipo = "PruebaTipo2",
                Numero = "1234123412344444",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",

            };

            int antes = sesionPrueba.ObtenerTodasLasTarjetas().Count();
            sesionPrueba.AltaTarjetaCredito(nuevoTarjetaPrueba);
            int despues = sesionPrueba.ObtenerTodasLasTarjetas().Count();
            Assert.AreEqual(1,despues - antes);
        }

        [TestMethod]
        public void SePuedeEjecutarBajaTarjetaEstandoLogueado()
        {
            int antes = sesionPrueba.ObtenerTodasLasTarjetas().Count();
            sesionPrueba.BajaTarjetaCredito(nuevoTarjeta.Id);
            int despues = sesionPrueba.ObtenerTodasLasTarjetas().Count();
            Assert.AreEqual(1, antes - despues);

        }

        [TestMethod]
        public void SePuedeEjecutarModificarTarjetaEstandoLogueado()
        {
            int id = nuevoTarjeta.Id;
            string nombreAnterior = nuevoTarjeta.Nombre;

            int idCat = sesionPrueba.AltaCategoria("fake");
            Categoria nuevaCat = sesionPrueba.BuscarCategoriaPorId(idCat);

            TarjetaCredito modificadaTarjetaPrueba = new TarjetaCredito()
            {
                Categoria = nuevaCat,
                Nombre = "nombreModificado",
                Tipo = "PruebaTipo2",
                Numero = "1234123412344444",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",
                Id = id
            };

            sesionPrueba.ModificarTarjeta(modificadaTarjetaPrueba);
            string nombreActual = sesionPrueba.BuscarTarjeta(nuevoTarjeta.Id).Nombre;
            Assert.AreNotEqual(nombreActual, nombreAnterior);
        }

        [TestMethod]
        public void SePuedeEjecutarBuscarTarjetaEstandoLogueado()
        {
            int id = sesionPrueba.AltaCategoria("fake");
            Categoria nuevaCat = sesionPrueba.BuscarCategoriaPorId(id);

            TarjetaCredito buscada = new TarjetaCredito()
            {
                Categoria = nuevaCat,
                Nombre = "tarjeta a Buscar",
                Tipo = "PruebaTipo2",
                Numero = "5555123412344444",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",
                
            };

            int idTarjeta = sesionPrueba.AltaTarjetaCredito(buscada);
            TarjetaCredito encontrada = sesionPrueba.BuscarTarjeta(idTarjeta);
            Assert.AreEqual(idTarjeta, encontrada.Id);
            
        }

        [TestMethod]
        public void SePuedeEjecutarObtenerTodasTarjetaEstandoLogueado()
        {
           int cantidad = sesionPrueba.ObtenerTodasLasTarjetas().Count();
           sesionPrueba.BajaTarjetaCredito(nuevoTarjeta.Id);
           Assert.AreEqual(1, cantidad - sesionPrueba.ObtenerTodasLasTarjetas().Count());

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarAltaContraseniaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.AltaContrasenia(new Contrasenia());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBajaContraseniaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BajaContrasenia(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarModificarContraseniaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ModificarContrasenia(new Contrasenia());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBuscarContraseniaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BuscarContrasenia(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarListarContraseniasSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ObtenerTodasLasContrasenias();
        }

     
        [TestMethod]
        public void SePuedeEjecutarAltaContraseniaEstandoLogueado()
        {
            int cantidadAntes = sesionPrueba.ObtenerTodasLasContrasenias().Count();
            int id = sesionPrueba.AltaCategoria("fake");
            Categoria nuevaCat = sesionPrueba.BuscarCategoriaPorId(id);

            Contrasenia contraseniaPrueba = new Contrasenia()
            {
                Sitio = "deremate.com.ar",
                Usuario = "fedexAlta",
                Password = new Password("dale%%vo111!!!"),
                Categoria = nuevaCat,
                Notas = "Sin"
            };

            sesionPrueba.AltaContrasenia(contraseniaPrueba);
            Assert.AreEqual(1, sesionPrueba.ObtenerTodasLasContrasenias().Count() - cantidadAntes);

        }

        [TestMethod]
        public void SePuedeEjecutarBajaContraseniaEstandoLogueado()
        {
           int cantidadAntes = sesionPrueba.ObtenerTodasLasContrasenias().Count();
           sesionPrueba.BajaContrasenia(pruebaContrasenia.ContraseniaId);
           int cantidadDespues = sesionPrueba.ObtenerTodasLasContrasenias().Count();
           Assert.AreEqual(1, cantidadAntes - cantidadDespues);

        }

        [TestMethod]
        public void SePuedeEjecutarModificarContraseniaEstandoLogueado()
        {

            Contrasenia anterior = sesionPrueba.ObtenerTodasLasContrasenias().First();
            string sitioViejo = anterior.Sitio;
            int idCat = sesionPrueba.AltaCategoria("Fake");
            Categoria categorianueva = sesionPrueba.BuscarCategoriaPorId(idCat);

            Contrasenia contraseniaModificar = new Contrasenia()
            {
                Sitio = "sitio nuevo",
                Usuario = "fedexAlta",
                Password = new Password("dale%%vo111!!!"),
                Categoria = categorianueva,
                Notas = "Sin",
                ContraseniaId = anterior.ContraseniaId
            };

            sesionPrueba.ModificarContrasenia(contraseniaModificar);

            Contrasenia nueva = sesionPrueba.BuscarContrasenia(anterior.ContraseniaId);
            string sitioNuevo = nueva.Sitio;

            Assert.AreNotEqual(sitioViejo, sitioNuevo);

        }

        [TestMethod]
        public void SePuedeEjecutarBuscarContraseniaEstandoLogueado()
        {
            int id = sesionPrueba.ObtenerTodasLasContrasenias().First().ContraseniaId;
            Contrasenia buscada = sesionPrueba.BuscarContrasenia(id);
            Assert.IsNotNull(buscada);
        }

        [TestMethod]
        public void SePuedeEjecutarListarContraseniasEstandoLogueado()
        {
            Contrasenia buscada = sesionPrueba.ObtenerTodasLasContrasenias().First();
            Assert.IsNotNull(buscada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoPuedeEjecutarMostrarPasswordNoEstandoLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.MostrarPassword(new Contrasenia());

        }

        [TestMethod]
        public void SePuedeEjecutarMostrarPasswordEstandoLogueado()
        {
            string password = sesionPrueba.MostrarPassword(pruebaContrasenia);
            Assert.AreEqual(pruebaContrasenia.Password.Clave, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeGuardarElPasswordMaestroMenorA5Caracteres()
        {
            sesionPrueba.GuardarPrimerPassword("aaaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeGuardarElPasswordMaestroMayorA25Caracteres()
        {
            sesionPrueba.GuardarPrimerPassword("12345123451234512345123451");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCambiarElPasswordMaestroMayorA25Caracteres()
        {
            sesionPrueba.CambiarPassword("12345123451234512345123451");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCambiarElPasswordMaestroMenorA5Caracteres()
        {
            sesionPrueba.CambiarPassword("aaaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void FallaElLoginConPasswordIncorrecto()
        {
            string primerPassword = "nuevoPasswrod";
            sesionPrueba.GuardarPrimerPassword(primerPassword);
            sesionPrueba.Login("assassa");
        }

        [TestMethod]
        public void AgregarContraseniaOTarjetaVulnerableAFuente()
        {
            sesionPrueba.CargarDataBreachLocal("admin123");
            int cantidadVecesEncontrada = sesionPrueba.VerificarPasswordFiltrado("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 1);
        }

        [TestMethod]
        public void Agregar2VecesLaMismaContraseniaOTarjetaVulnerableAFuente()
        {
            sesionPrueba.CargarDataBreachLocal("admin123");
            sesionPrueba.CargarDataBreachLocal("admin123");
            int cantidadVecesEncontrada = sesionPrueba.VerificarPasswordFiltrado("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 2);
        }

        [TestMethod]
        public void EncuentraContraseniaVulnerableEnFuente()
        {

            sesionPrueba.ContraseniasVulnerables();
            Contrasenia vulnerable = sesionPrueba.BuscarContrasenia(pruebaContrasenia.ContraseniaId);
            Assert.AreEqual(1, vulnerable.CantidadVecesEncontradaVulnerable);

        }

        [TestMethod]
        public void Encuentra2VecesUnaContraseniaVulnerableEnUnaFuente()
        {
            sesionPrueba.CargarDataBreachLocal("dalevo111!!!");
            sesionPrueba.ContraseniasVulnerables();
            pruebaContrasenia = sesionPrueba.BuscarContrasenia(pruebaContrasenia.ContraseniaId);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 2);
        }

        [TestMethod]
        public void AciertaDosVecesLasContraseniasVulnerables()
        {

            IEnumerable<Contrasenia> contrasenias = sesionPrueba.ContraseniasVulnerables();
            IEnumerable<Contrasenia> contrasenias2 = sesionPrueba.ContraseniasVulnerables();
            Assert.AreEqual(contrasenias.Count(), contrasenias2.Count());

        }

        [TestMethod]
        public void EncuentraTarjetaVulnerableEnFuente()
        {

            sesionPrueba.TarjetasCreditoVulnerables();
            nuevoTarjeta = sesionPrueba.BuscarTarjeta(nuevoTarjeta.Id);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesTarjetaVulnerableEnUnaFuente()
        {
            sesionPrueba.CargarDataBreachLocal("1234123412341234");
            sesionPrueba.TarjetasCreditoVulnerables();
            nuevoTarjeta = sesionPrueba.BuscarTarjeta(nuevoTarjeta.Id);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 2);

        }

        [TestMethod]
        public void SiApareceMuchasVecesVulnerableDevuelveUnSoloObjeto()
        {

            sesionPrueba.CargarDataBreachLocal("1234123412341234");
            sesionPrueba.CargarDataBreachLocal("1234123412341234");
            IEnumerable<TarjetaCredito> tarjetasVulnerables = sesionPrueba.TarjetasCreditoVulnerables();
            Assert.AreEqual(1, tarjetasVulnerables.Count());

        }

        [TestMethod]
        public void SePuedeModificarElPassword()
        {
            Contrasenia aModificar = sesionPrueba.ObtenerTodasLasContrasenias().First();
            int idPass = aModificar.ContraseniaId;
            string passAnterior = sesionPrueba.MostrarPassword(aModificar);
            aModificar.Password = new Password("secretoNuevo");
            sesionPrueba.ModificarContrasenia(aModificar);

            Contrasenia modificada = sesionPrueba.BuscarContrasenia(idPass);
            string passActual = sesionPrueba.MostrarPassword(aModificar);

            Assert.AreNotEqual(passAnterior, passActual);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void NoSePuedeAgregarUnaContraseniaSiNoExisteLaCategoria()
        {
            Contrasenia nueva = new Contrasenia()
            {
                Categoria = new Categoria("Nombre X")
                {
                    Id = 50
                },
                Password = new Password("passs"),
                Sitio = "un sitio X",
                Usuario= "un usuario X"
            };
            sesionPrueba.AltaContrasenia(nueva);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void NoSePuedeAgregarUnaTarjetaSiNoExisteLaCategoria()
        {
            TarjetaCredito nueva = new TarjetaCredito()
            {
                Categoria = new Categoria("Nombre X")
                {
                    Id = 50
                },
                Codigo="123",
                Numero="1231231231231231",
                Nombre="tarjeta x",
                Tipo="Tarjeta",
                Vencimiento = DateTime.Now
            };
            sesionPrueba.AltaTarjetaCredito(nueva);
        }

        [TestMethod]
        public void SePuedeGenerarUnHistorial()
        {
            int historial = sesionPrueba.ConsultarVulnerabilidades();
            Assert.IsNotNull(historial);
        }

        [TestMethod]
        public void ElHistorialDevulveContraseniasVulnerables()
        {
            int historial = sesionPrueba.ConsultarVulnerabilidades();
            IEnumerable<HistorialContrasenia> contraseniaVulnerable = sesionPrueba.DevolverContraseniasVulnerables(historial);

            Assert.AreEqual(1,contraseniaVulnerable.Count());
            Assert.AreEqual("dalevo111!!!", contraseniaVulnerable.First().Clave);
            Assert.AreEqual(pruebaContrasenia.ContraseniaId, contraseniaVulnerable.First().ContraseniaId);
        }

        [TestMethod]
        public void ElHistorialDevulveTarjetasVulnerables()
        {
            int historial = sesionPrueba.ConsultarVulnerabilidades();
            IEnumerable<HistorialTarjetas> tarjetasVulnerable = sesionPrueba.DevolverTarjetasVulnerables(historial);

            Assert.AreEqual(1, tarjetasVulnerable.Count());
            Assert.AreEqual("1234123412341234", tarjetasVulnerable.First().NumeroTarjeta);
        }

        [TestMethod]
        public void SeDevulvenHistoriales()
        {
            int historial = sesionPrueba.ConsultarVulnerabilidades();
            int historial2 = sesionPrueba.ConsultarVulnerabilidades();
            IEnumerable<Historial> historiales = sesionPrueba.ObtenerTodasLosHistoriales();

            Assert.AreEqual(2, historiales.Count());
        }

        [TestMethod]
        public void SeGeneranGrupos()
        {
            pruebaContrasenia.Password.Clave = "1234567";
            pruebaContrasenia.Usuario = "ussu1";
            sesionPrueba.AltaContrasenia(pruebaContrasenia);

            pruebaContrasenia.Password.Clave = "12345678";
            pruebaContrasenia.Usuario = "ussu2";
            sesionPrueba.AltaContrasenia(pruebaContrasenia);

            pruebaContrasenia.Password.Clave = "aaaaaaaaaaaaaaa";
            pruebaContrasenia.Usuario = "ussu3";
            sesionPrueba.AltaContrasenia(pruebaContrasenia);

            pruebaContrasenia.Password.Clave = "AAAAAAaAAAAAAAA";
            pruebaContrasenia.Usuario = "ussu4";
            sesionPrueba.AltaContrasenia(pruebaContrasenia);

            pruebaContrasenia.Password.Clave = " AAAA1@ AAAAAAA";
            pruebaContrasenia.Usuario = "ussu5";
            sesionPrueba.AltaContrasenia(pruebaContrasenia);

            pruebaContrasenia.Password.Clave = "AAAAAAaAAAA$AA1";
            pruebaContrasenia.Usuario = "ussu6";
            sesionPrueba.AltaContrasenia(pruebaContrasenia);

            List<Grupo> grupos = sesionPrueba.GenerarGrupos();
            Assert.IsNotNull(grupos);
        }
        [TestMethod]
        public void LaSesionMeDevuelveElColorDeUnPassword()
        {
            string password = "HolaSecretoPassword";
            string fortaleza = sesionPrueba.VerificarFortalezaPassword(password);
            Assert.AreEqual("VERDE_CLARO", fortaleza);
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoDevuelveElColorDeUnPasswordSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            string password = "HolaSecretoPassword";
            string fortaleza = sesionPrueba.VerificarFortalezaPassword(password);
        }
        [TestMethod]
        public void LaSesionMeDevuelveSiElPasswordEsRepetido()
        {
            int id = sesionPrueba.AltaCategoria("Mas Cosas");
            Categoria nuevaCategoriaPrueba = sesionPrueba.BuscarCategoriaPorId(id);
            Contrasenia pruebaContrasenia2 = new Contrasenia()
            {
                Sitio = "deremate.com",
                Usuario = "deremate",
                Password = new Password("dalevo111!!!"),
                Categoria = nuevaCategoriaPrueba,
                Notas = "Sin"
            };

            sesionPrueba.AltaContrasenia(pruebaContrasenia2);

            string password = "dalevo111!!!";

            int vecesRepetido = sesionPrueba.VerificarCatidadVecesPasswordRepetido(password);
            Assert.AreEqual(2, vecesRepetido);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSeGeneranGruposSinLoguearse()
        {
            sesionPrueba.LogOut();
            List<Grupo> grupos = sesionPrueba.GenerarGrupos();

        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoDevuelveSiElPasswordEsRepetidoSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            string password = "HolaSecretoPassword";
            sesionPrueba.VerificarCatidadVecesPasswordRepetido(password);
        }

    
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoDevuelveSiElPasswordSeFiltroSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            string password = "dalevo111!!!";
            sesionPrueba.VerificarPasswordFiltrado(password);
        }

        [TestMethod]
        public void LaSesionPermiteEliminarLosArchivosDataBreach()
        {
            sesionPrueba.BajaDataBreachArchivos();
            int contador = 0;
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (Directory.Exists(rutaDirectorio))
            {
                List<string> strFiles = Directory.GetFiles(rutaDirectorio, "*", SearchOption.AllDirectories).ToList();

                foreach (string fichero in strFiles)
                {
                    contador++;
                }
            }
            Assert.AreEqual(0, contador);
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoPermiteEliminarLosArchivosDataBreachSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BajaDataBreachArchivos();
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoPermiteEliminarLaFuenteLocalSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BajaDataBreachLocal();
        }
        private string ArmarTextoDeLargoVariable(int largo)
        {

            string retorno = "";
            for (int i = 0; i < largo; i++)
            {
                retorno += "a";

            }
            return retorno;

        }

    }
}
