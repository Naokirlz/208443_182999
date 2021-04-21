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
            Contrasenia nuevaContrasenia = new Contrasenia();
            nuevaContrasenia.SetFechaUltimaModificacion(fechaCreacion);
            //{
            //    FechaUltimaModificacion = fechaCreacion
            //};
            Assert.AreEqual(fechaCreacion, nuevaContrasenia.GetFechaUltimaModificacion());
        }

        [TestMethod]
        public void SeGuardaLaFechaDeModificacionCorrecta()
        {
            DateTime fechaActual = DateTime.Now;
            Contrasenia nuevaContrasenia = new Contrasenia();
            nuevaContrasenia.SetFechaUltimaModificacion(fechaActual);
            //{
            //    FechaUltimaModificacion = fechaActual
            //};
            Assert.AreEqual(fechaActual, nuevaContrasenia.GetFechaUltimaModificacion());
        }
        [TestMethod]
        public void SePuedeCrearUnaContraseniaConNotaCorrecta()
        {
            string notas = "notas";
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Notas = notas
            };
            Assert.AreEqual(notas, nuevaContrasenia.Notas);
        }

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConCategoria()
        {
            Negocio.Categoria unaCategoria = new Negocio.Categoria("una categoría");
            Contrasenia nuevaContrasenia = new Contrasenia();
            nuevaContrasenia.SetCategoriaPass(unaCategoria);
            Assert.AreEqual("una categoría", nuevaContrasenia.GetCategoriaPass().Nombre);
        }

    }
}
