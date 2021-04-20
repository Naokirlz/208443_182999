using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Clases;
using Negocio.Excepciones;

namespace PruebasUnitarias.Contrasena
{
    [TestClass]
    public class PruebasContrasena
    {
        [TestMethod]
        public void SePuedeCrearUnaContrasenaConSitioCorrecto()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() { 
                Sitio = "12345",
            };
            Assert.AreEqual("12345", nuevaContrasenia.Sitio);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConSitioMenor3Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() {
                Sitio = "12"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConSitioMayor25Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() {
                Sitio = "12345123451234512345123451"
            };
        }

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConUsuarioCorrecto()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() {
                Usuario = "12345"
            };
            Assert.AreEqual("12345", nuevaContrasenia.Usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConUsuarioMenor5Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia();
            nuevaContrasenia.Usuario = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConUsuarioMayor25Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia();
            nuevaContrasenia.Usuario = "12345123451234512345123451";
        }

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConPasswordCorrecto()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() { 
                Password = "12345"
            };
            Assert.AreEqual("12345", nuevaContrasenia.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConPasswordMenor5Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() {
                Password = "1234"
            };
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConPasswordfMayor25Caracteres()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Password = "12345123451234512345123451"
            };
        }

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConCategoria()
        {
            Categoria unaCategoria = new Categoria("una categoría"); 
            Contrasenia nuevaContrasenia = new Contrasenia() { 
                Categoria = unaCategoria
            };
            Assert.AreEqual("una categoría", nuevaContrasenia.Categoria.Nombre);
        }

        [TestMethod]
        public void SePuedeCrearUnaContraseniaConNotaCorrecta()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() { 
                Notas = "Notas"
            };
            Assert.AreEqual("Notas", nuevaContrasenia.Notas);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConNotasMayor250Caracteres()
        {
            string unaNota = "";
            for (int caracter = 0; caracter <= 250; caracter++) unaNota += "a";
            Contrasenia nuevaContrasenia = new Contrasenia() { 
                Notas = unaNota,
            };
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
            Assert.AreEqual(fechaCreacion, nuevaContrasenia.FechaUltimaModificacion);
        }

        [TestMethod]
        public void SeGuardaLaFechaModificacionCorrecta()
        {
            DateTime fechaCreacion = DateTime.Now;
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                FechaUltimaModificacion = fechaCreacion
            };
            Assert.AreEqual(fechaCreacion, nuevaContrasenia.FechaUltimaModificacion);
        }
    }
}
