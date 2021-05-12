using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.Contrasenias;
using Negocio.Categorias;
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
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                FechaUltimaModificacion = DateTime.Now
            };
            Assert.AreEqual(DateTime.Now, nuevaContrasenia.FechaUltimaModificacion);
        }

        [TestMethod]
        public void SePuedeCrearUnaContraseniaConNotaCorrecta()
        {
             Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Notas = "notas"
            };
            Assert.AreEqual("notas", nuevaContrasenia.Notas);
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
            
            Assert.AreEqual("deremate.com | fede", nuevaContrasenia.ToString());
        }

        [TestMethod]
        public void SePuedeDetectarPasswordColorRojo()
        {
            ContraseniaCompleta.Password.Clave = "1234567";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("ROJO", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarPasswordColorNaranja()
        {
            ContraseniaCompleta.Password.Clave = "12345678";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("NARANJA", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarPasswordAmarilloSoloMinusculas()
        {
            ContraseniaCompleta.Password.Clave = "aaaaaaaaaaaaaaa";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("AMARILLO", fortaleza);
        }
        [TestMethod]
        public void SePuedeDetectarPasswordAmarilloSoloMayusculas()
        {
            ContraseniaCompleta.Password.Clave = "AAAAAAAAAAAAAAA";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("AMARILLO", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarPasswordVerdeClaro()
        {
            ContraseniaCompleta.Password.Clave = "AAAAAAaAAAAAAAA";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("VERDE_CLARO", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarMayusculasEspecialesNumerosMayor14VerdeClaro()
        {
            ContraseniaCompleta.Password.Clave = " AAAA1@ AAAAAAA";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("VERDE_CLARO", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarMinusculasEspecialesNumerosMayor14VerdeClaro()
        {
            ContraseniaCompleta.Password.Clave = "aaaaa1@aaaaaaaa";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("VERDE_CLARO", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarPasswordVerdeOscuro()
        {
            ContraseniaCompleta.Password.Clave = "AAAAAAaAAAA$AA1";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("VERDE_OSCURO", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarOtroPasswordVerdeOscuro()
        {
            ContraseniaCompleta.Password.Clave = "^ AA;AaA}}AA#AA1";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("VERDE_OSCURO", fortaleza);
        }

        [TestMethod]
        public void SePuedeDetectarPasswordVerdeOscuroPorBug()
        {
            ContraseniaCompleta.Password.Clave = "u9_ANu9_ANu9_ANu9_AN";
            string fortaleza = ContraseniaCompleta.FortalezaDelPassword().ToString();
            Assert.AreEqual("VERDE_OSCURO", fortaleza);
        }
    }
}
