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
                Password = new Password("secreto")
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
                Password = new Password("secreto")
            };
            Gestor.Alta(nuevaContrasena);
            IEnumerable<Contrasenia> contrasenias = Gestor.ObtenerTodas();
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
            ContraseniaCompleta.Password.Clave = "12345123451234512345123451";
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeCrearUnaContrasenaConPasswordMenor5Caracteres()
        {
            ContraseniaCompleta.Password.Clave = "1234";
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
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            Assert.AreNotEqual(fechaIncorrecta, nuevaContrasenia.FechaUltimaModificacion);
            Assert.AreEqual(DateTime.Now.Date, nuevaContrasenia.FechaUltimaModificacion.Date);
        }

        //se puede cambiar el sitio
        [TestMethod]
        public void SePuedeModificarElSitio()
        {
            ContraseniaCompleta.Sitio = "sitioviejo.com";
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            
            ContraseniaCompleta = Gestor.Buscar(idNuevaContrasenia);
            ContraseniaCompleta.Sitio = "nuevositio.com";
            Gestor.ModificarContrasenia(ContraseniaCompleta);

            Assert.AreEqual("nuevositio.com", Gestor.Buscar(idNuevaContrasenia).Sitio);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElSitioConMenos3Caracteres()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Sitio = "nu";
            Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElSitioConMas25Caracteres()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            ContraseniaCompleta = Gestor.Buscar(idNuevaContrasenia);
            ContraseniaCompleta.Sitio = "12345123451234512345123451";
            Gestor.ModificarContrasenia(ContraseniaCompleta);
        }

        [TestMethod]
        public void AlGuardarUnaContraseniaCreadaNoSeModificaMandadaPorParametro()
        {
            ContraseniaCompleta.Sitio = "sitioviejo.com";
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Sitio = "12345123451234512345123451";
            Assert.AreNotEqual("12345123451234512345123451", Gestor.Buscar(nuevaContrasenia.Id).Sitio);
        }

        [TestMethod]
        public void SePuedeBuscarUnaContrasenia()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            Contrasenia buscada = Gestor.Buscar(nuevaContrasenia.Id);
            Assert.AreEqual(nuevaContrasenia.Sitio, buscada.Sitio);
        }

        [TestMethod]
        public void AlModificarUnaContraseniaCreadaNoSeModificaMandadaPorParametro()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            string datoAnterior = nuevaContrasenia.Sitio;
            nuevaContrasenia.Sitio = "12345123451234512345123451";
           
            Contrasenia buscada = Gestor.Buscar(idNuevaContrasenia);
            Assert.AreNotEqual("12345123451234512345123451", buscada.Sitio);
        }

        [TestMethod]
        public void SeAsignaElIdAutoincremental()
        {
                        
            int idUnaContrasenia = Gestor.Alta(ContraseniaCompleta);
            
            Contrasenia nuevaContrasenia = new Contrasenia() {
                Sitio = "otrositio.com",
                Categoria = new Categoria("Categoria"),
                Usuario = "usuario",
                Notas = "clave de netflix",
                FechaUltimaModificacion = DateTime.Now,
                Password = new Password("secreto")
            };

            int idOtraContrasenia = Gestor.Alta(nuevaContrasenia);
            
            int diferencia = idOtraContrasenia - idUnaContrasenia;
            Assert.AreEqual(1, diferencia);
        }

        //se puede cambiar el usuario
        [TestMethod]
        public void SePuedeModificarElUsuario()
        {
            ContraseniaCompleta.Usuario = "usuario anterior";
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Usuario = "usuario nuevo";
            Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual("usuario nuevo", Gestor.Buscar(idNuevaContrasenia).Usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElUsuarioConMenos5Caracteres()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Usuario = "usua";
            Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElUsuarioConMas25Caracteres()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Usuario = "12345123451234512345123451";
            Gestor.ModificarContrasenia(nuevaContrasenia);
        }

       

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElPasswordConMenos5Caracteres()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Password.Clave = "1234";
            Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarElPasswordConMas25Caracteres()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Password.Clave = "12345123451234512345123451";
            Gestor.ModificarContrasenia(nuevaContrasenia);
        }

        //se puede cambiar la categoria
        [TestMethod]
        public void SePuedeModificarLaCategoria()
        {
            Categoria nuevaCat = new Categoria("categoria nueva");
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Categoria = nuevaCat;
            Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual(nuevaCat.Nombre, Gestor.Buscar(idNuevaContrasenia).Categoria.Nombre);
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
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Notas = "nuevas notas";
            Gestor.ModificarContrasenia(nuevaContrasenia);
            Assert.AreEqual("nuevas notas", Gestor.Buscar(idNuevaContrasenia).Notas);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeModificarLasNotasConMas250Caracteres()
        {
            string unaNota = "";
            for (int caracter = 0; caracter <= 250; caracter++) unaNota += "a";
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            nuevaContrasenia.Notas = unaNota;
            Gestor.ModificarContrasenia(nuevaContrasenia);
        }
        

        //se puede autogenerar la password en una cantidad correcta de caracteres
        [TestMethod]
        public void SePuedeGenerarPasswordPorCaracteres()
        {
            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = false,
                Minuscula = true,
                Numero = false,
                Especial = false
            };

            nuevo.GenerarPassword();

            Assert.AreEqual(13, nuevo.Clave.Length);
        }

        //se puede autogenerar la password en una cantidad correcta de tipos de caracteres
        //se puede autogenerar password con minusculas
        [TestMethod]
        public void SePuedeGenerarPasswordConMinusculas()
        {
            bool hayMinuscula = false;
            bool NohayOtro = true;

            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = false,
                Minuscula = true,
                Numero = false,
                Especial = false
            };
            nuevo.GenerarPassword();

            foreach (char caracter in nuevo.Clave)
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
            bool hayMayuscula = false;
            bool NohayOtro = true;

            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = true,
                Minuscula = false,
                Numero = false,
                Especial = false
            };
            nuevo.GenerarPassword();

            foreach (char caracter in nuevo.Clave)
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
            bool hayMayuscula = false;
            bool hayMinuscula = false;
            bool NohayOtro = true;

            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = true,
                Minuscula = true,
                Numero = false,
                Especial = false
            };
            nuevo.GenerarPassword();
            
            foreach (char caracter in nuevo.Clave)
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
            bool hayNumeros = false;
            bool NohayOtro = true;

            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = false,
                Minuscula = false,
                Numero = true,
                Especial = false
            };
            nuevo.GenerarPassword();
            
            foreach (char caracter in nuevo.Clave)
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
            bool hayEspeciales = false;
            bool NohayOtro = true;

            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = false,
                Minuscula = false,
                Numero = false,
                Especial = true
            };
            nuevo.GenerarPassword();


            foreach (char caracter in nuevo.Clave)
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
            bool hayMayuscula = false;
            bool hayMinuscula = false;
            bool hayEspeciales = false;
            bool hayNumeros = false;
            bool NohayOtro = true;

            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = true,
                Minuscula = true,
                Numero = true,
                Especial = true
            };
            nuevo.GenerarPassword();


            foreach (char caracter in nuevo.Clave)
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
            ContraseniaCompleta.Password.Clave = "secreto";
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nueva = Gestor.Buscar(idNuevaContrasenia);
            Assert.AreNotEqual("secreto", nueva.Password);
        }

        //se puede desencriptar el password
      

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
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia unaC = Gestor.Buscar(idNuevaContrasenia);
            
            ContraseniaCompleta.Sitio = "otro sitio distinto";
            
            int idOtraNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia dosC = Gestor.Buscar(idNuevaContrasenia);
                        
            Assert.AreEqual(2, Gestor.ObtenerTodas().Count());
        }

        //no se guarda la contraseña que mando por parámetro
        [TestMethod]
        public void SeGuardaLaContraseniaQueSeMandaPorParametro()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia unaC = Gestor.Buscar(idNuevaContrasenia);
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
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            int cantidadAntes = Gestor.ObtenerTodas().Count();
            Gestor.Baja(idNuevaContrasenia);
            int cantidadDespues = Gestor.ObtenerTodas().Count();
            Assert.AreEqual(1 , cantidadAntes - cantidadDespues);
        }

        [TestMethod]
        public void AlAutogenerarUnPasswordNoMeDevuelveTodosLosCaracteresIguales()
        {
            //no sería una buena prueba, hay que refactorizar, el que no me devuelva dos caracteres seguidos iguales surge porque devolvía todos los caracteres iguales, la intención es que no los devolviera todos iguales, pero dos iguales podía haber, pero para lograrlo a veces pasa y otras no, hay que verlo
            
            Password nuevo = new Password("")
            {
                Largo = 4,
                Mayuscula = false,
                Minuscula = true,
                Numero = false,
                Especial = false
            };
            nuevo.GenerarPassword();

            string password = nuevo.Clave;
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
                Password = new Password("secreto555")
            };
            Gestor.Alta(nuevaContrasena);

            Contrasenia nuevaContrasena2 = new Contrasenia()
            {
                Categoria = new Categoria("BBBBBB"),
                Usuario = "usuario2",
                Sitio = "tcc",
                Notas = "clave de tcc",
                FechaUltimaModificacion = DateTime.Now,
                Password = new Password("secreto555")
            };
            Gestor.Alta(nuevaContrasena2);


            IEnumerable<Contrasenia> contrasenias = Gestor.ObtenerTodas();

            Assert.AreEqual("AAAAAA", contrasenias.ElementAt(0).Categoria.Nombre);
            Assert.AreEqual("BBBBBB", contrasenias.ElementAt(1).Categoria.Nombre);
            Assert.AreEqual("ZZZZZZ", contrasenias.ElementAt(2).Categoria.Nombre);


        }
        
        [TestMethod]
        public void NoActualizaFechaActualizacionAlModificarOtroAtributoQueNoSeaPassword()
        {
            Gestor.Alta(ContraseniaCompleta);
            Contrasenia vieja = Gestor.ObtenerTodas().First();
            DateTime fechaVieja = vieja.FechaUltimaModificacion;
            int id = vieja.Id;


            Contrasenia contraseniaNueva = new Contrasenia()
            {
                Sitio = "OTRO SITIO",
                Categoria = vieja.Categoria,
                Usuario = vieja.Usuario,
                Notas = vieja.Notas,
                FechaUltimaModificacion = vieja.FechaUltimaModificacion,
                Id = vieja.Id,
                Password = vieja.Password
            };

            Gestor.ModificarContrasenia(contraseniaNueva);
            Contrasenia nueva = Gestor.Buscar(id);
            DateTime fechaNueva = nueva.FechaUltimaModificacion;
            Assert.AreEqual(fechaVieja, fechaNueva);

        }
        
        [TestMethod]
        public void SeActualizaFechaActualizacionAlModificarPassword()
        {
            Gestor.Alta(ContraseniaCompleta);
            Contrasenia vieja = Gestor.ObtenerTodas().First();
            DateTime fechaVieja = vieja.FechaUltimaModificacion;
            int id = vieja.Id;


            Contrasenia contraseniaNueva = new Contrasenia()
            {
                Sitio = vieja.Sitio,
                Categoria = vieja.Categoria,
                Usuario = vieja.Usuario,
                Notas = vieja.Notas,
                FechaUltimaModificacion = vieja.FechaUltimaModificacion,
                Id= vieja.Id,
                Password = new Password("Nuevo PASSWORD")
            };

            Gestor.ModificarContrasenia(contraseniaNueva);
            Contrasenia nueva = Gestor.Buscar(id);
            DateTime fechaNueva = nueva.FechaUltimaModificacion;
            Assert.AreNotEqual(fechaVieja, fechaNueva);

        }




    }
}
