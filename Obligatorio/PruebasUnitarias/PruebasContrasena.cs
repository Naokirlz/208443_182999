using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.Contrasenias;
using Negocio.Categorias;
using Negocio.Excepciones;
using System;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasContrasena
    {
        [TestCleanup]

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConSitioCorrecto()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Sitio = "12345",
            };
            Assert.AreEqual("12345", nuevaContrasenia.Sitio);
        }

        

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConUsuarioCorrecto()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Usuario = "12345"
            };
            Assert.AreEqual("12345", nuevaContrasenia.Usuario);
        }

        

        

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConPasswordCorrecto()
        {
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Password = "12345"
            };
            Assert.AreEqual("12345", nuevaContrasenia.Password);
        }

        
        

        

        

        [TestMethod]
        public void SeGuardaLaFechaDeModificacionCorrecta()
        {
            DateTime fechaActual = DateTime.Now;
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                FechaUltimaModificacion = fechaActual
            };
            Assert.AreEqual(fechaActual, nuevaContrasenia.FechaUltimaModificacion);
        }

        [TestMethod]
        public void SePuedeCrearUnaContraseniaConNotaCorrecta()
        {
            string notas = "notas";
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Notas = notas
            };
            //Contrasenia nuevaContrasenia = new Contrasenia();
            //nuevaContrasenia.SetNotas(notas);
            Assert.AreEqual(notas, nuevaContrasenia.Notas);
        }

        [TestMethod]
        public void SePuedeCrearUnaContrasenaConCategoria()
        {
            Categoria unaCategoria = new Categoria("una categoría");
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Categoria = unaCategoria
            };
            Assert.AreEqual("una categoría", nuevaContrasenia.Categoria.Nombre);
        }

        [TestMethod]
        public void ElMetodoToStringDevuelveElUsuarioYSitio()
        {
            Contrasenia nuevaContrasenia = new Contrasenia() { 
                Sitio = "deremate.com",
                Usuario = "fede"
            };
            string texto = nuevaContrasenia.ToString();
            Assert.AreEqual("deremate.com | fede", texto);
        }
    }
}
