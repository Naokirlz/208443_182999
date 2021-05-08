using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Excepciones;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
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
            sesionPrueba = Sesion.Singleton;
            sesionPrueba.GuardarPrimerPassword("secreto");
            sesionPrueba.Login("secreto");
            Fuente = new FuenteLocal();

            this.nuevoTarjeta = new TarjetaCredito()
            {
                Categoria = new Categoria("Fake"),
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
                Password = "dalevo111!!!",
                Categoria = new Categoria("Fake"),
                Notas = "Sin"
            };

            sesionPrueba.GestorTarjetaCredito.Alta(nuevoTarjeta);
            sesionPrueba.GestorContrasenia.Alta(pruebaContrasenia);
            sesionPrueba.MisFuentes.Add(Fuente);
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("dalevo111!!!");
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");
        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesionPrueba.GestorContrasenia = new GestorContrasenias();
            sesionPrueba.GestorTarjetaCredito = new GestorTarjetaCredito();
            sesionPrueba.GestorCategoria = new GestorCategorias();
            sesionPrueba.MisFuentes = new List<IFuente>();
        }

        //[TestMethod]
        //public void InicioSesionCorrecto()
        //{
        //    sesionPrueba.GuardarPrimerPassword("secreto");
        //    sesionPrueba.Login("secreto");
        //    sesionPrueba.GestorCategoria.Alta("cat uno");
        //    Assert.AreEqual(1, sesionPrueba.GestorCategoria.ObtenerTodasLasCategorias().Count());
        //}

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeIniciarSesionSinIngresarElPrimerPassword()
        {
            sesionPrueba.Login("");
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
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarModificarCategoriaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.ModificacionCategoria(1, "nuevoNombre");
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

            Categoria nuevaCategoria = sesionPrueba.AltaCategoria("algunaCategoria");
            int id = nuevaCategoria.Id;
            sesionPrueba.ModificacionCategoria(id, "modAlgunaCat");

            Assert.AreEqual("modAlgunaCat", sesionPrueba.BuscarCategoriaPorId(id).Nombre);

        }

        [TestMethod]
        public void SePuedeEjecutarBuscarCategoriaPorIdSiSeEstaLogueado()
        {
            Categoria nuevaCategoria = sesionPrueba.AltaCategoria("viejaCategoria");
            int id = nuevaCategoria.Id;

            Categoria categoriaBuscada = sesionPrueba.BuscarCategoriaPorId(id);
           
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
            sesionPrueba.BajaTarjetaCredito(new TarjetaCredito());
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
            sesionPrueba.BuscarTarjeta(new TarjetaCredito());
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
                TarjetaCredito nuevoTarjetaPrueba = new TarjetaCredito()
            {
                Categoria = new Categoria("Prueba"),
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
            sesionPrueba.BajaTarjetaCredito(nuevoTarjeta);
            int despues = sesionPrueba.ObtenerTodasLasTarjetas().Count();
            Assert.AreEqual(1, antes - despues);

        }

        [TestMethod]
        
        public void SePuedeEjecutarModificarTarjetaEstandoLogueado()
        {
            int id = nuevoTarjeta.IdTarjeta;
            string nombreAnterior = nuevoTarjeta.Nombre;

            TarjetaCredito modificadaTarjetaPrueba = new TarjetaCredito()
            {
                Categoria = new Categoria("Prueba"),
                Nombre = "nombreModificado",
                Tipo = "PruebaTipo2",
                Numero = "1234123412344444",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",
                IdTarjeta = id
            };

            sesionPrueba.ModificarTarjeta(modificadaTarjetaPrueba);
            string nombreActual = sesionPrueba.BuscarTarjeta(nuevoTarjeta).Nombre;
            Assert.AreNotEqual(nombreActual, nombreAnterior);
        }

        [TestMethod]
        
        public void SePuedeEjecutarBuscarTarjetaEstandoLogueado()
        {
             TarjetaCredito buscada = new TarjetaCredito()
            {
                Categoria = new Categoria("Prueba"),
                Nombre = "tarjeta a Buscar",
                Tipo = "PruebaTipo2",
                Numero = "5555123412344444",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",
                
            };

            int idTarjeta = sesionPrueba.AltaTarjetaCredito(buscada).IdTarjeta;
            TarjetaCredito encontrada = sesionPrueba.BuscarTarjeta(buscada);
            Assert.AreEqual(idTarjeta, encontrada.IdTarjeta);
            
        }

        [TestMethod]
        
        public void SePuedeEjecutarObtenerTodasTarjetaEstandoLogueado()
        {
           int cantidad = sesionPrueba.ObtenerTodasLasTarjetas().Count();
           sesionPrueba.BajaTarjetaCredito(nuevoTarjeta);
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
            sesionPrueba.ListarContrasenias();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarVerificarFortalezaSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.VerificarFortaleza(new Contrasenia());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarGenerarPasswordSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.GenerarPassword(1,false,false,false,false);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAccesoDenegado))]
        public void NoSePuedeEjecutarMostrarPasswordSiNoSeEstaLogueado()
        {
            sesionPrueba.LogOut();
            sesionPrueba.MostrarPassword("password");
        }

        //

        [TestMethod]
        
        public void SePuedeEjecutarAltaContraseniaEstandoLogueado()
        {
            int cantidadAntes = sesionPrueba.ListarContrasenias().Count();
            
            Contrasenia contraseniaPrueba = new Contrasenia()
            {
                Sitio = "deremate.com.ar",
                Usuario = "fedexAlta",
                Password = "dale%%vo111!!!",
                Categoria = new Categoria("Fake"),
                Notas = "Sin"
            };

            sesionPrueba.AltaContrasenia(contraseniaPrueba);
            Assert.AreEqual(1, sesionPrueba.ListarContrasenias().Count() - cantidadAntes);

        }

        [TestMethod]
        
        public void SePuedeEjecutarBajaContraseniaEstandoLogueado()
        {
           int cantidadAntes = sesionPrueba.ListarContrasenias().Count();
           sesionPrueba.BajaContrasenia(pruebaContrasenia.Id);
           int cantidadDespues = sesionPrueba.ListarContrasenias().Count();
           Assert.AreEqual(1, cantidadAntes - cantidadDespues);

        }

        [TestMethod]
        
        public void SePuedeEjecutarModificarContraseniaEstandoLogueado()
        {

            Contrasenia anterior = sesionPrueba.ListarContrasenias()[0];
            string sitioViejo = anterior.Sitio;
                        
            Contrasenia contraseniaModificar = new Contrasenia()
            {
                Sitio = "sitio nuevo",
                Usuario = "fedexAlta",
                Password = "dale%%vo111!!!",
                Categoria = new Categoria("Fake"),
                Notas = "Sin",
                Id = anterior.Id
            };

            sesionPrueba.ModificarContrasenia(contraseniaModificar);

            Contrasenia nueva = sesionPrueba.ListarContrasenias()[0];
            string sitioNuevo = anterior.Sitio;

            Assert.AreNotEqual(sitioViejo, sitioNuevo);

        }

        [TestMethod]
       
        public void SePuedeEjecutarBuscarContraseniaEstandoLogueado()
        {
            int id = sesionPrueba.ListarContrasenias()[0].Id;
            Contrasenia buscada = sesionPrueba.BuscarContrasenia(id);
            Assert.IsNotNull(buscada);
        }

        [TestMethod]
       
        public void SePuedeEjecutarListarContraseniasEstandoLogueado()
        {
            Contrasenia buscada = sesionPrueba.ListarContrasenias()[0];
            Assert.IsNotNull(buscada);
        }

        [TestMethod]
        
        public void SePuedeEjecutarVerificarFortalezaEstandoLogueado()
        {
            string fortaleza = "Nada que Reportar";
            fortaleza = sesionPrueba.VerificarFortaleza(pruebaContrasenia);
            Assert.AreNotEqual("Nada que Reportar", fortaleza);
        }

        [TestMethod]
       
        
        public void SePuedeEjecutarGenerarPasswordEstandoLogueado()
        {
            string password = "Nada generado";
            password = sesionPrueba.GenerarPassword(5, true, false, false, false);
            Assert.AreNotEqual("Nada generado", password);
        }

        [TestMethod]
        
        public void SePuedeEjecutarMostrarPasswordEstandoLogueado()
        {
            string encriptado = sesionPrueba.GenerarPassword(5, true, false, false, false);
            string password = sesionPrueba.MostrarPassword(encriptado);
            Assert.AreEqual(encriptado, password);
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
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void SeDebeTrimarElPasswordMaestro()
        {
            sesionPrueba.GuardarPrimerPassword("aaaa       ");
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
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("admin123");
            int cantidadVecesEncontrada = sesionPrueba.MisFuentes[0].BuscarPasswordOContraseniaEnFuente("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AgregarContraseniaOTarjetaVulnerableAFuenteMayorA50Caracteres()
        {
            string texto = ArmarTextoDeLargoVariable(51);
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable(texto);
           
        }

        [TestMethod]
        public void Agregar2VecesLaMismaContraseniaOTarjetaVulnerableAFuente()
        {
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("admin123");
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("admin123");
            int cantidadVecesEncontrada = sesionPrueba.MisFuentes[0].BuscarPasswordOContraseniaEnFuente("admin123");
            Assert.AreEqual(cantidadVecesEncontrada, 2);

        }


        [TestMethod]
        public void EncuentraContraseniaVulnerableEnFuente()
        {
       
            sesionPrueba.ContraseniasVulnerables(Fuente);
            pruebaContrasenia = sesionPrueba.GestorContrasenia.Buscar(pruebaContrasenia.Id);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesUnaContraseniaVulnerableEnUnaFuente()
        {
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("dalevo111!!!");
           
            sesionPrueba.ContraseniasVulnerables(Fuente);
            pruebaContrasenia = sesionPrueba.GestorContrasenia.Buscar(pruebaContrasenia.Id);
            Assert.AreEqual(pruebaContrasenia.CantidadVecesEncontradaVulnerable, 2);
           
           
        }

        [TestMethod]
        public void AciertaDosVecesLasContraseniasVulnerables()
        {

            List<Contrasenia> contrasenias = sesionPrueba.ContraseniasVulnerables(Fuente);
            List<Contrasenia> contrasenias2 = sesionPrueba.ContraseniasVulnerables(Fuente);
            Assert.AreEqual(contrasenias.Count(), contrasenias2.Count());

        }


        [TestMethod]
        public void EncuentraTarjetaVulnerableEnFuente()
        {
            
            sesionPrueba.TarjetasCreditoVulnerables(Fuente);
            nuevoTarjeta = sesionPrueba.GestorTarjetaCredito.Buscar(nuevoTarjeta);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 1);

        }

        [TestMethod]
        public void Encuentra2VecesTarjetaVulnerableEnUnaFuente()
        {
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");

            sesionPrueba.TarjetasCreditoVulnerables(Fuente);
            nuevoTarjeta = sesionPrueba.GestorTarjetaCredito.Buscar(nuevoTarjeta);
            Assert.AreEqual(nuevoTarjeta.CantidadVecesEncontradaVulnerable, 2);

        }

        [TestMethod]
        public void SiApareceMuchasVecesVulnerableDevuelveUnSoloObjeto()
        {

            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");
            sesionPrueba.MisFuentes[0].AgregarPasswordOContraseniaVulnerable("1234123412341234");

            List<TarjetaCredito> tarjetasVulnerables = sesionPrueba.TarjetasCreditoVulnerables(Fuente);

            Assert.AreEqual(1, tarjetasVulnerables.Count());

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
