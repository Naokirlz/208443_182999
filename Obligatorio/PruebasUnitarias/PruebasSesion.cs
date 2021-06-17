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
    [TestClass]
    public class PruebasSesion
    {
        private Sesion sesionPrueba;
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
            FuenteLocal fuente = new FuenteLocal();
            sesionPrueba.CargarDataBreach(fuente, "dalevo111!!!\n1234123412341234");
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesionPrueba.VaciarDatosPrueba();            
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
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarBuscarCategoriaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.BuscarCategoriaPorId(1);
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
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarAltaContraseniaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.AltaContrasenia(new Contrasenia());
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
        public void SePuedeEjecutarBuscarContraseniaEstandoLogueado()
        {
            int id = sesionPrueba.ObtenerTodasLasContrasenias().First().ContraseniaId;
            Contrasenia buscada = sesionPrueba.BuscarContrasenia(id);
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
        public void EncuentraContraseniaVulnerableEnFuente()
        {

            sesionPrueba.ContraseniasVulnerables();
            Contrasenia vulnerable = sesionPrueba.BuscarContrasenia(pruebaContrasenia.ContraseniaId);
            Assert.AreEqual(1, vulnerable.CantidadVecesEncontradaVulnerable);

        }

        [TestMethod]
        public void Encuentra2VecesUnaContraseniaVulnerableEnUnaFuente()
        {
            FuenteLocal fuente = new FuenteLocal();
            sesionPrueba.CargarDataBreach(fuente, "dalevo111!!!");
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
            FuenteLocal fuente = new FuenteLocal();
            sesionPrueba.CargarDataBreach(fuente, "1234123412341234");
            sesionPrueba.TarjetasCreditoVulnerables();
            nuevoTarjeta = sesionPrueba.BuscarTarjeta(nuevoTarjeta.Id);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 2);

        }

        [TestMethod]
        public void SiApareceMuchasVecesVulnerableDevuelveUnSoloObjeto()
        {
            FuenteLocal fuente = new FuenteLocal();
            sesionPrueba.CargarDataBreach(fuente, "1234123412341234");
            sesionPrueba.CargarDataBreach(fuente, "1234123412341234");
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
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoDevuelveElColorDeUnPasswordSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            string password = "HolaSecretoPassword";
            string fortaleza = sesionPrueba.VerificarFortalezaPassword(password);
        }
        

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSeGeneranGruposSinLoguearse()
        {
            sesionPrueba.LogOut();
            List<Grupo> grupos = sesionPrueba.GenerarGrupos().ToList();

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
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoPermiteEliminarLosArchivosDataBreachSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.LimpiarFuentes();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void LaSesionNoPermiteEliminarLaFuenteLocalSiNoEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.LimpiarFuentes();
        }

        [TestMethod]
        public void SePuedeVerificarSiExisteUsuario()
        {
            Assert.IsTrue(sesionPrueba.VerificarUsuarioExiste());
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
