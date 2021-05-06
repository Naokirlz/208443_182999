using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Contrasenias;
using Negocio.Categorias;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasGestorContrasenia
    {
        //no se puede guardar una contraseña con categoria que no existe //hacer junto con Cristian
        // validar categoria antes de crearla y antes de modificar
        // se deja test de validar la fecha para luego
        

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
            ContraseniaCompleta.FechaUltimaModificacion = fechaCreacion;
            Gestor.Alta(ContraseniaCompleta);
            Assert.AreEqual(fechaCreacion, ContraseniaCompleta.FechaUltimaModificacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConNotasMayor250Caracteres()
        {
            string unaNota = "";
            for (int caracter = 0; caracter <= 250; caracter++) unaNota += "a";
            ContraseniaCompleta.Notas = unaNota;
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConPasswordfMayor25Caracteres()
        {
            ContraseniaCompleta.Password = "12345123451234512345123451";
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConPasswordMenor5Caracteres()
        {
            ContraseniaCompleta.Password = "1234";
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConUsuarioMenor5Caracteres()
        {
            ContraseniaCompleta.Usuario = "1234";
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConUsuarioMayor25Caracteres()
        {
            ContraseniaCompleta.Usuario = "12345123451234512345123451";
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConSitioMenor3Caracteres()
        {
            ContraseniaCompleta.Sitio = "12";
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConSitioMayor25Caracteres()
        {
            ContraseniaCompleta.Sitio = "12345123451234512345123451";
            Gestor.Alta(ContraseniaCompleta);
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
            Assert.AreNotEqual("12345123451234512345123451", Gestor.Buscar(nuevaContrasenia.Id).Sitio);
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
            Contrasenia nuevaContrasenia = new Contrasenia() {
                Sitio = "otrositio.com",
                Categoria = new Categoria("Categoria"),
                Usuario = "usuario",
                Notas = "clave de netflix",
                FechaUltimaModificacion = DateTime.Now,
                Password = "secreto"
            };
            Contrasenia otraContrasenia = Gestor.Alta(nuevaContrasenia);
            int diferencia = otraContrasenia.Id - unaContrasenia.Id;
            Assert.AreEqual(1, diferencia);
        }

        //se puede cambiar el usuario
        [TestMethod]
        public void SePuedeModificarElUsuario()
        {
            ContraseniaCompleta.Usuario = "usuario anterior";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Usuario = "usuario nuevo";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual("usuario nuevo", modificada.Usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElUsuarioConMenos5Caracteres()
        {
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Usuario = "usua";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElUsuarioConMas25Caracteres()
        {
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Usuario = "12345123451234512345123451";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        //se puede cambiar el password
        [TestMethod]
        public void SePuedeModificarElPassword()
        {
            ContraseniaCompleta.Password = "secretoAnterior";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Password = "secretoNuevo";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual("secretoNuevo", Gestor.MostrarPassword(modificada.Password));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElPasswordConMenos5Caracteres()
        {
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Password = "1234";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElPasswordConMas25Caracteres()
        {
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Password = "12345123451234512345123451";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        //se puede cambiar la categoria
        [TestMethod]
        public void SePuedeModificarLaCategoria()
        {
            Categoria nuevaCat = new Categoria("categoria nueva");
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Categoria = nuevaCat;
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual(nuevaCat.Nombre, modificada.Categoria.Nombre);
        }

        //se modifica la fecha de modificacion correctamente cuando se modifica un atributo
        //[TestMethod]
        //public void SeModificaLaFechaDeModificacionAlModificarAtributos()
        //{
        //    Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
        //    nuevaContrasenia.Sitio = "sitio nuevo";
        //    Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        //    Assert.AreNotEqual(nuevaContrasenia.FechaUltimaModificacion, modificada.FechaUltimaModificacion);
        //}

        //se puede cambiar las notas
        [TestMethod]
        public void SePuedeModificarLasNotas()
        {
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Notas = "nuevas notas";
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual("nuevas notas", modificada.Notas);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarLasNotasConMas250Caracteres()
        {
            string unaNota = "";
            for (int caracter = 0; caracter <= 250; caracter++) unaNota += "a";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            nuevaContrasenia.Notas = unaNota;
            Contrasenia modificada = Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        /************************************************
         *    VALIDACIONES DE PASSWORD
         * ************************************************/
        // se puede detectar password en rojo
        [TestMethod]
        public void SePuedeDetectarPasswordRojo()
        {
            ContraseniaCompleta.Password = "1234567";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            string fortaleza = Gestor.VerificarFortaleza(nuevaContrasenia);
            Assert.AreEqual("ROJO", fortaleza);
        }

        // se puede detectar password en NARANJA
        [TestMethod]
        public void SePuedeDetectarPasswordNaranja()
        {
            ContraseniaCompleta.Password = "12345678";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            string fortaleza = Gestor.VerificarFortaleza(nuevaContrasenia);
            Assert.AreEqual("NARANJA", fortaleza);
        }

        // se puede detectar password en AMARILLO
        [TestMethod]
        public void SePuedeDetectarPasswordAmarilloSoloMinusculas()
        {
            ContraseniaCompleta.Password = "aaaaaaaaaaaaaaa";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            string fortaleza = Gestor.VerificarFortaleza(nuevaContrasenia);
            Assert.AreEqual("AMARILLO", fortaleza);
        }
        [TestMethod]
        public void SePuedeDetectarPasswordAmarilloSoloMayusculas()
        {
            ContraseniaCompleta.Password = "AAAAAAAAAAAAAAA";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            string fortaleza = Gestor.VerificarFortaleza(nuevaContrasenia);
            Assert.AreEqual("AMARILLO", fortaleza);
        }

        // se puede detectar password en VERDE CLARO
        [TestMethod]
        public void SePuedeDetectarPasswordVerdeClaro()
        {
            ContraseniaCompleta.Password = "AAAAAAaAAAAAAAA";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            string fortaleza = Gestor.VerificarFortaleza(nuevaContrasenia);
            Assert.AreEqual("VERDE CLARO", fortaleza);
        }

        // se puede detectar password en VERDE OSCURO
        [TestMethod]
        public void SePuedeDetectarPasswordVerdeOscuro()
        {
            ContraseniaCompleta.Password = "AAAAAAaAAAA$AA1";
            Contrasenia nuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            string fortaleza = Gestor.VerificarFortaleza(nuevaContrasenia);
            Assert.AreEqual("VERDE OSCURO", fortaleza);
        }

        //se puede autogenerar la password en una cantidad correcta de caracteres
        [TestMethod]
        public void SePuedeGenerarPasswordPorCaracteres()
        {
            string password = Gestor.GenerarPassword(13, false,true,false,false);
            Assert.AreEqual(13, password.Length);
        }

        //se puede autogenerar la password en una cantidad correcta de tipos de caracteres
        //se puede autogenerar password con minusculas
        [TestMethod]
        public void SePuedeGenerarPasswordConMinusculas()
        {
            string password = Gestor.GenerarPassword(13, false, true, false, false);
            bool hayMinuscula = false;
            bool NohayOtro = true;

            foreach (char caracter in password)
            {
                if (caracter >= 97 && caracter <= 122) hayMinuscula = true;
                else NohayOtro = false;
            }
            Assert.IsTrue(hayMinuscula && NohayOtro);
        }
        //se puede autogenerar password con mayusculas
        [TestMethod]
        public void SePuedeGenerarPasswordConMayusculas()
        {
            string password = Gestor.GenerarPassword(13, true, false, false, false);
            bool hayMayuscula = false;
            bool NohayOtro = true;

            foreach (char caracter in password)
            {
                if (caracter >= 65 && caracter <= 90) hayMayuscula = true;
                else NohayOtro = false;
            }
            Assert.IsTrue(hayMayuscula && NohayOtro);
        }
        //se puede autogenerar password con mayusculas y minusculas
        [TestMethod]
        public void SePuedeGenerarPasswordConMayusculasYMinusculas()
        {
            string password = Gestor.GenerarPassword(13, true, true, false, false);
            bool hayMayuscula = false;
            bool hayMinuscula = false;
            bool NohayOtro = true;

            foreach (char caracter in password)
            {
                if (caracter >= 65 && caracter <= 90) hayMayuscula = true;
                else if (caracter >= 97 && caracter <= 122) hayMinuscula = true;
                else NohayOtro = false;
            }
            Assert.IsTrue(hayMayuscula && hayMinuscula && NohayOtro);
        }
        //se puede autogenerar password con numeros
        [TestMethod]
        public void SePuedeGenerarPasswordConNumeross()
        {
            string password = Gestor.GenerarPassword(13, false, false, true, false);
            bool hayNumeros = false;
            bool NohayOtro = true;

            foreach (char caracter in password)
            {
                if (caracter >= 48 && caracter <= 57) hayNumeros = true;
                else NohayOtro = false;
            }
            Assert.IsTrue(hayNumeros && NohayOtro);
        }
        //se puede autogenerar password con especiales
        [TestMethod]
        public void SePuedeGenerarPasswordConEspeciales()
        {
            string password = Gestor.GenerarPassword(13, false, false, false, true);
            bool hayEspeciales = false;
            bool NohayOtro = true;

            foreach (char caracter in password)
            {
                if (caracter >= 32 && caracter <= 47) hayEspeciales = true;
                else if(caracter >= 58 && caracter <= 64) hayEspeciales = true;
                else if(caracter >= 91 && caracter <= 96) hayEspeciales = true;
                else if(caracter >= 123 && caracter <= 126) hayEspeciales = true;
                else NohayOtro = false;
            }
            Assert.IsTrue(hayEspeciales && NohayOtro);
        }
        //se puede autogenerar password con todos los tipos
        [TestMethod]
        public void SePuedeGenerarPasswordConTodosLosTipos()
        {
            string password = Gestor.GenerarPassword(13, true, true, true, true);
            bool hayMayuscula = false;
            bool hayMinuscula = false;
            bool hayEspeciales = false;
            bool hayNumeros = false;
            bool NohayOtro = true;

            foreach (char caracter in password)
            {
                if (caracter >= 65 && caracter <= 90) hayMayuscula = true;
                else if (caracter >= 97 && caracter <= 122) hayMinuscula = true;
                else if (caracter >= 32 && caracter <= 47) hayEspeciales = true;
                else if (caracter >= 58 && caracter <= 64) hayEspeciales = true;
                else if (caracter >= 91 && caracter <= 96) hayEspeciales = true;
                else if (caracter >= 123 && caracter <= 126) hayEspeciales = true;
                else if (caracter >= 48 && caracter <= 57) hayNumeros = true;
                else NohayOtro = false;
            }
            Assert.IsTrue(hayMayuscula && hayMinuscula && hayEspeciales && hayNumeros && NohayOtro);
        }

        //la password no se guarda en texto plano
        [TestMethod]
        public void SeGuardaElPasswordCodificado()
        {
            ContraseniaCompleta.Password = "secreto";
            Contrasenia nueva = Gestor.Alta(ContraseniaCompleta);
            Assert.AreNotEqual("secreto", nueva.Password);
        }

        //se puede desencriptar el password
        [TestMethod]
        public void SePuedeDesencriptarElPassword()
        {
            ContraseniaCompleta.Password = "secreto";
            Contrasenia nueva = Gestor.Alta(ContraseniaCompleta);
            Assert.AreEqual("secreto", Gestor.MostrarPassword(nueva.Password));
        }

        //sitio y usuario tienen solo una contraseña
        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedenGuardarDosPasswrodConMismoUsuarioYSitio()
        {
            Gestor.Alta(ContraseniaCompleta);
            Gestor.Alta(ContraseniaCompleta);
        }

        //se pueden listar las contrasenias
        [TestMethod]
        public void SePuedePuedenListarLasContrasenias()
        {
            Contrasenia unaC = Gestor.Alta(ContraseniaCompleta);
            ContraseniaCompleta.Sitio = "otro sitio distinto";
            Contrasenia dosC = Gestor.Alta(ContraseniaCompleta);
            Assert.AreEqual(2, Gestor.ListarContrasenias().Count);
        }

        //no se guarda la contraseña que mando por parámetro
        [TestMethod]
        public void SeGuardaLaContraseniaQueSeMandaPorParametro()
        {
            Contrasenia unaC = Gestor.Alta(ContraseniaCompleta);
            ContraseniaCompleta.Sitio = "otro sitio distinto";
            Contrasenia guardada = Gestor.Buscar(unaC.Id);
            Assert.AreNotEqual("otro sitio distinto", guardada.Sitio);
        }

        //No se encuentra una contraseña que no existe
        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void NoSeEncuentraContraseniaQueNoExiste()
        {
            Gestor.Buscar(75);
        }

        [TestMethod]
        public void SePuedeBorrarUnaContrasenia()
        {
            Contrasenia nuevaConstrasenia = Gestor.Alta(ContraseniaCompleta);
            Gestor.Baja(nuevaConstrasenia.Id);
            Assert.AreEqual(0, Gestor.ListarContrasenias().Count);
        }

        [TestMethod]
        public void AlAutogenerarUnPasswordNoMeDevuelveTodosLosCaracteresIguales()
        {
            //no sería una buena prueba, hay que refactorizar, el que no me devuelva dos caracteres seguidos iguales surge porque devolvía todos los caracteres iguales, la intención es que no los devolviera todos iguales, pero dos iguales podía haber, pero para lograrlo a veces pasa y otras no, hay que verlo
            string password = Gestor.GenerarPassword(4, false, true, false, false);
            bool todosIguales = true;
            char caracterAnterior = new char();

            foreach (char c in password)
            {
                if (c != caracterAnterior) todosIguales = false;
                caracterAnterior = c;
            }

            Assert.IsFalse(todosIguales);
        }

        [TestMethod]
        public void ListarContraseniaOrdenadaPorNombreCategoria()
        {
            ContraseniaCompleta.Categoria.Nombre = "ZZZZZZ";
            Gestor.Alta(ContraseniaCompleta);

            Contrasenia nuevaContrasena = new Contrasenia()
            {
                Categoria = new Categoria("AAAAAA"),
                Usuario = "usuario",
                Sitio = "netflix",
                Notas = "clave de netflix",
                FechaUltimaModificacion = DateTime.Now,
                Password = "secreto555"
            };
            Gestor.Alta(nuevaContrasena);

            Contrasenia nuevaContrasena2 = new Contrasenia()
            {
                Categoria = new Categoria("BBBBBB"),
                Usuario = "usuario2",
                Sitio = "tcc",
                Notas = "clave de tcc",
                FechaUltimaModificacion = DateTime.Now,
                Password = "secreto555"
            };
            Gestor.Alta(nuevaContrasena2);


            List<Contrasenia> contrasenias = Gestor.ListarContrasenias();

            Assert.AreEqual("AAAAAA", contrasenias[0].Categoria.Nombre);
            Assert.AreEqual("BBBBBB", contrasenias[1].Categoria.Nombre);
            Assert.AreEqual("ZZZZZZ", contrasenias[2].Categoria.Nombre);


        }
    }
}
