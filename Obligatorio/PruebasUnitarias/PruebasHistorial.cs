using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.TarjetaCreditos;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Negocio.DataBreaches;
using Negocio.Persistencia.EntityFramework;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasHistorial
    {
        Sesion sesionPrueba;
        FuenteLocal Fuente;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;
        private GestorDataBreaches Gestor;


        [TestInitialize]
        public void InicializarPruebas()
        {

            sesionPrueba = Sesion.ObtenerInstancia();
            sesionPrueba.VaciarDatosPrueba();
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
            sesionPrueba.FuenteLocal.CrearDataBreach("dalevo111!!!\n1234123412341234");

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
        public void SePuedeGuardiarHistorial2Tarjeta()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;

            HistorialTarjetas nuevo = new HistorialTarjetas();
            nuevo.NumeroTarjeta = "1234123412341234";
            historial.tarjetasVulnerables.Add(nuevo);

            HistorialTarjetas nuevo2 = new HistorialTarjetas();
            nuevo2.NumeroTarjeta = "1234123412349999";
            historial.tarjetasVulnerables.Add(nuevo2);

            int registroHistorial = sesionPrueba.AltaHistorial(historial);
            

            Assert.IsNotNull(registroHistorial);

        }

        [TestMethod]
        public void SePuedeGuardarHistorial2Contrasenia()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;

            HistorialContrasenia nuevo = new HistorialContrasenia();
            nuevo.ContraseniaId = pruebaContrasenia.ContraseniaId;
            historial.passwords.Add(nuevo);


            int registroHistorial = sesionPrueba.AltaHistorial(historial);

            Assert.IsNotNull(registroHistorial);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void SePuedeEliminarunHistorial()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            int registroHistorial = sesionPrueba.AltaHistorial(historial);
                        
            Assert.IsNotNull(registroHistorial);
            sesionPrueba.BajaHistorial(registroHistorial);
            sesionPrueba.BuscarHistorial(registroHistorial);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEliminarunHistorialSinLoguearse()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            int registroHistorial = sesionPrueba.AltaHistorial(historial);

            sesionPrueba.LogOut();
            sesionPrueba.BajaHistorial(registroHistorial);
   
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void NoSePuedeEliminarunHistorialQueNoExiste()
        {
           sesionPrueba.BajaHistorial(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoSePuedeModificarHistorial()
        {
            RepositorioDataBreachesEntity nuevo = new RepositorioDataBreachesEntity();
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            nuevo.Alta(historial);
            historial.Fecha = DateTime.Now.AddDays(10);
            nuevo.Modificar(historial);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoSePuedeBorrarTest()
        {
            RepositorioDataBreachesEntity nuevo = new RepositorioDataBreachesEntity();
            nuevo.TestClear();

        }




        [TestMethod]
        public void SePuedeBudvstunHistorial()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            int registroHistorial = sesionPrueba.AltaHistorial(historial);
            Historial buscado = sesionPrueba.BuscarHistorial(registroHistorial);
            Assert.IsNotNull(buscado);
   
        }

        [TestMethod]
        public void SePuedeObtenerHistorialGuardado()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            HistorialContrasenia nuevo = new HistorialContrasenia();
            nuevo.ContraseniaId = pruebaContrasenia.ContraseniaId;
            historial.passwords.Add(nuevo);
            int registroHistorial = sesionPrueba.AltaHistorial(historial);

            IEnumerable<Historial> guardado = sesionPrueba.ObtenerTodasLosHistoriales();

            Assert.IsNotNull(guardado);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeObtenerHistorialGuardadoSinLoguearse()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ObtenerTodasLosHistoriales();
         }

        [TestMethod]
        public void SePuedeObtenerTarjetasVulnerablesDeUnHistorial()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            HistorialContrasenia nuevo = new HistorialContrasenia();
            nuevo.ContraseniaId = pruebaContrasenia.ContraseniaId;
            historial.passwords.Add(nuevo);
            int registroHistorial = sesionPrueba.AltaHistorial(historial);
            IEnumerable<HistorialTarjetas> historialTarjetas = sesionPrueba.DevolverTarjetasVulnerables(registroHistorial);
            Assert.IsNotNull(historialTarjetas);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeObtenerTarjetasVulnerablesDeUnHistorialSinLoguearse()
        {
            sesionPrueba.LogOut();
            sesionPrueba.DevolverTarjetasVulnerables(1);
        }

        [TestMethod]
        public void SePuedeObtenerContraseniasVulnerablesDeUnHistorial()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            HistorialContrasenia nuevo = new HistorialContrasenia();
            nuevo.ContraseniaId = pruebaContrasenia.ContraseniaId;
            historial.passwords.Add(nuevo);
            int registroHistorial = sesionPrueba.AltaHistorial(historial);
            IEnumerable<HistorialContrasenia> historialContrasenias = sesionPrueba.DevolverContraseniasVulnerables(registroHistorial);
            Assert.IsNotNull(historialContrasenias);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeObtenerContraseniasVulnerablesDeUnHistorialSinLoguearse()
        {
            sesionPrueba.LogOut();
            sesionPrueba.DevolverContraseniasVulnerables(1);
          

        }

        [TestMethod]
        public void SeRegistraUnaConsultaDeVulnerabilidades()
        {  
            int consulta1= sesionPrueba.ConsultarVulnerabilidades();
            int consulta2 = sesionPrueba.ConsultarVulnerabilidades();
            Assert.AreEqual(1, consulta2 - consulta1);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSeRegistraUnaConsultaDeVulnerabilidadesSinLoguearse()
        {
            sesionPrueba.LogOut();
            int consulta1 = sesionPrueba.ConsultarVulnerabilidades();
            int consulta2 = sesionPrueba.ConsultarVulnerabilidades();
            Assert.AreEqual(1, consulta2 - consulta1);

        }

        [TestMethod]
        public void SePuedeDarDeAltaUnHistorial()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            HistorialContrasenia nuevo = new HistorialContrasenia();
            nuevo.ContraseniaId = pruebaContrasenia.ContraseniaId;
            historial.passwords.Add(nuevo);
            int registroHistorial = sesionPrueba.AltaHistorial(historial);

            Assert.IsNotNull(registroHistorial);
            

        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeDarDeAltaUnHistorialSinLoguearse()
        {
            sesionPrueba.LogOut();
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            HistorialContrasenia nuevo = new HistorialContrasenia();
            nuevo.ContraseniaId = pruebaContrasenia.ContraseniaId;
            historial.passwords.Add(nuevo);
            int registroHistorial = sesionPrueba.AltaHistorial(historial);

            Assert.IsNotNull(registroHistorial);


        }


        [TestMethod]
        public void SePuedeBuscarUnUnHistorial()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            HistorialContrasenia nuevo = new HistorialContrasenia();
            nuevo.ContraseniaId = pruebaContrasenia.ContraseniaId;
            historial.passwords.Add(nuevo);
            int registroHistorial = sesionPrueba.AltaHistorial(historial);

            Historial buscado = sesionPrueba.BuscarHistorial(registroHistorial);
            Assert.IsNotNull(buscado);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeBuscarUnUnHistorialSinLoguearse()
        {
            sesionPrueba.LogOut();
            Historial buscado = sesionPrueba.BuscarHistorial(1);

        }

    }

}
