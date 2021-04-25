using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Clases;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasContraseniaGestor
    {
        //no se puede guardar una contraseña con categoria que no existe //hacer junto con Cristian

       
        
        //se puede cambiar el usuario
        //se puede cambiar el password
        //se puede cambiar la categoria
        //se modifica la fecha de modificacion correctamente en cambio de sitio
        //se modifica la fecha de modificacion correctamente en cambio de usuario
        //se modifica la fecha de modificacion correctamente en cambio de password
        //se modifica la fecha de modificacion correctamente en cambio de categoria
        //se puede autogenerar la password en una cantidad correcta de caracteres
        //se puede autogenerar la password en una cantidad correcta de tipos de caracteres
        //se puede obtener la fuerza de la contraseña
        //sitio y usuario tienen solo una contraseña
        //la password no se guarda en texto plano

        private GestorContrasenias Gestor = new GestorContrasenias();
        private Contrasenia ContraseniaCompleta;

        [TestInitialize]
        public void TestInitialize()
        {
            Contrasenia contraseniaCompleta = new Contrasenia() { 
                Sitio="unsitio.com",
                Categoria = new Categoria("Categoria"),
                Usuario = "usuario",
                Notas = "clave de netflix",
                FechaUltimaModificacion = DateTime.Now,
                Password = "secreto"
            };
            this.ContraseniaCompleta = contraseniaCompleta;
        }

        // se puede guardar una contraseña correctamente
        [TestMethod]
        public void SePuedeGuardarCorrectamente()
        {
            Categoria categoria = new Categoria("Categoría");
            Contrasenia nuevaContrasena = new Contrasenia()
            {
                Categoria = categoria,
                Usuario = "usuario",
                Sitio = "netflix",
                Notas = "clave de netflix",
                FechaUltimaModificacion = DateTime.Now,
                Password = "secreto"
            };
            Gestor.Alta(nuevaContrasena);
            List<Contrasenia> contrasenias = Gestor.ListarContrasenias();
            bool existe = contrasenias.Any(c => c.Usuario == nuevaContrasena.Usuario && c.Sitio == nuevaContrasena.Sitio);
            Assert.IsTrue(existe);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionFechaIncorrecta))]
        public void NoSeGuardaContraseniaSiFechaModificacionEsFuturo()
        {
            DateTime fechaCreacion = DateTime.Now.AddDays(1);
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                FechaUltimaModificacion = fechaCreacion
            };
            Gestor.Alta(nuevaContrasenia);
            Assert.AreEqual(fechaCreacion, nuevaContrasenia.FechaUltimaModificacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConNotasMayor250Caracteres()
        {
            string unaNota = "";
            for (int caracter = 0; caracter <= 250; caracter++) unaNota += "a";
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Notas = unaNota,
            };
            Gestor.Alta(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConPasswordfMayor25Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Password = "12345123451234512345123451"
            };
            Gestor.Alta(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConPasswordMenor5Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Password = "1234"
            };
            Gestor.Alta(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConUsuarioMenor5Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia();
            nuevaContrasenia.Usuario = "1234";
            Gestor.Alta(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConUsuarioMayor25Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia();
            nuevaContrasenia.Usuario = "12345123451234512345123451";
            Gestor.Alta(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConSitioMenor3Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Sitio = "12"
            };
            Gestor.Alta(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConSitioMayor25Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Sitio = "12345123451234512345123451"
            };
            Gestor.Alta(nuevaContrasenia);
        }

        //no se puede guardar una contraseña sin sitio
        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinSitio()
        {
            ContraseniaCompleta.Sitio = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        //no se puede guardar una contraseña sin usuario
        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinUsuario()
        {
            ContraseniaCompleta.Usuario = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        //no se puede guardar una contraseña sin password
        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinPassword()
        {
            ContraseniaCompleta.Password = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        //no se puede guardar una contraseña sin categoria
        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinCategoria()
        {
            ContraseniaCompleta.Categoria = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        //se corrige la fecha de modificacién aunque se mande por parámetro
        [TestMethod]
        public void SeCorrigeLaFechaDeModificacionAunqueSeMandePorParametro()
        {
            DateTime fechaIncorrecta = DateTime.Now.AddDays(-1);
            ContraseniaCompleta.FechaUltimaModificacion = fechaIncorrecta;
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Assert.AreNotEqual(fechaIncorrecta, nuevaContrasenia.FechaUltimaModificacion);
            Assert.AreEqual(DateTime.Now.Date, nuevaContrasenia.FechaUltimaModificacion.Date);
        }

        //se puede cambiar el sitio
        [TestMethod]
        public void SePuedeModificarElSitio()
        {
            ContraseniaCompleta.Sitio = "sitioviejo.com";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Sitio = "nuevositio.com";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual("nuevositio.com", modificada.Sitio);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElSitioConMenos3Caracteres()
        {
            ContraseniaCompleta.Sitio = "sitioviejo.com";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Sitio = "nu";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElSitioConMas25Caracteres()
        {
            ContraseniaCompleta.Sitio = "sitioviejo.com";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Sitio = "12345123451234512345123451";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        [TestMethod]
        public void AlGuardarUnaContraseniaCreadaNoSeModificaMandadaPorParametro()
        {
            ContraseniaCompleta.Sitio = "sitioviejo.com";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Sitio = "12345123451234512345123451";
            Assert.AreNotEqual("12345123451234512345123451", ContraseniaCompleta.Sitio);
        }

        [TestMethod]
        public void SePuedeBuscarUnaContrasenia()
        {
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia buscada = Gestor.Buscar(nuevaContrasenia.Id);
            Assert.AreEqual(nuevaContrasenia.Sitio, buscada.Sitio);
        }

        [TestMethod]
        public void AlModificarUnaContraseniaCreadaNoSeModificaMandadaPorParametro()
        {
            ContraseniaCompleta.Sitio = "sitioviejo.com";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Sitio = "1234512345";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
            modificada.Sitio = "12345123451234512345123451";
            Contrasenia buscada = Gestor.Buscar(modificada.Id);
            Assert.AreNotEqual("12345123451234512345123451", buscada.Sitio);
        }

        [TestMethod]
        public void SeAsignaElIdAutoincremental()
        {
            Contrasenia unaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia otraContrasenia = Gestor.Alta(ContraseniaCompleta);
            int diferencia = otraContrasenia.Id - unaContrasenia.Id;
            Assert.AreEqual(1, diferencia);
        }
    }
}
