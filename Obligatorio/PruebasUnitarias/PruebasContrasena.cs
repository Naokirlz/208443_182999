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

        
        private Contrasenia ContraseniaCompleta;

        [TestInitialize]
        public void TestInitialize()
        {
            Contrasenia contraseniaCompleta = new Contrasenia()
            {
                Sitio = "unsitio.com",
                Categoria = new Categoria("Categoria"),
                Usuario = "usuario",
                Notas = "clave de netflix",
                FechaUltimaModificacion = DateTime.Now,
                Password = new Password("secreto")
            };
            this.ContraseniaCompleta = contraseniaCompleta;
        }





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
                Password = new Password("12345")
            };
            Assert.AreEqual("12345", nuevaContrasenia.Password.Clave);
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

        /************************************************
         *    VALIDACIONES DE PASSWORD
         * ************************************************/
        // se puede detectar password en rojo
        [TestMethod]
        public void SePuedeDetectarPasswordRojo()
        {
            ContraseniaCompleta.Password.Clave = "1234567";
            string fortaleza = ContraseniaCompleta.Password.ColorPassword.ToString();
            Assert.AreEqual("ROJO", fortaleza);
        }

        // se puede detectar password en NARANJA
        [TestMethod]
        public void SePuedeDetectarPasswordNaranja()
        {
            ContraseniaCompleta.Password.Clave = "12345678";
            string fortaleza = ContraseniaCompleta.Password.ColorPassword.ToString();
            Assert.AreEqual("NARANJA", fortaleza);
        }

        // se puede detectar password en AMARILLO
        [TestMethod]
        public void SePuedeDetectarPasswordAmarilloSoloMinusculas()
        {
            ContraseniaCompleta.Password.Clave = "aaaaaaaaaaaaaaa";
            string fortaleza = ContraseniaCompleta.Password.ColorPassword.ToString();
            Assert.AreEqual("AMARILLO", fortaleza);
        }
        [TestMethod]
        public void SePuedeDetectarPasswordAmarilloSoloMayusculas()
        {
            ContraseniaCompleta.Password.Clave = "AAAAAAAAAAAAAAA";
            string fortaleza = ContraseniaCompleta.Password.ColorPassword.ToString();
            Assert.AreEqual("AMARILLO", fortaleza);
        }

        // se puede detectar password en VERDE CLARO
        [TestMethod]
        public void SePuedeDetectarPasswordVerdeClaro()
        {
            ContraseniaCompleta.Password.Clave = "AAAAAAaAAAAAAAA";
            string fortaleza = ContraseniaCompleta.Password.ColorPassword.ToString();
            Assert.AreEqual("VERDE_CLARO", fortaleza);
        }

        // se puede detectar password en VERDE OSCURO
        [TestMethod]
        public void SePuedeDetectarPasswordVerdeOscuro()
        {
            ContraseniaCompleta.Password.Clave = "AAAAAAaAAAA$AA1";
            string fortaleza = ContraseniaCompleta.Password.ColorPassword.ToString();
            Assert.AreEqual("VERDE_OSCURO", fortaleza);
        }
    }
}
