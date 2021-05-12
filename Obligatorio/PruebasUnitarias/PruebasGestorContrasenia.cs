using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Contrasenias;
using Negocio.Categorias;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasGestorContrasenia
    {
  
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

        [TestMethod]
        public void SePuedeGuardarCorrectamente()
        {
           
            Contrasenia nuevaContrasena = new Contrasenia()
            {
                Categoria = new Categoria("Categoría"),
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

        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinSitio()
        {
            ContraseniaCompleta.Sitio = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinUsuario()
        {
            ContraseniaCompleta.Usuario = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinPassword()
        {
            ContraseniaCompleta.Password = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionFaltaAtributo))]
        public void NoSePuedeGuardarUnaContrasenaSinCategoria()
        {
            ContraseniaCompleta.Categoria = null;
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        public void SeCorrigeLaFechaDeModificacionAunqueSeMandePorParametro()
        {
            ContraseniaCompleta.FechaUltimaModificacion = DateTime.Now.AddDays(-1);
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            Assert.AreNotEqual(DateTime.Now.AddDays(-1), nuevaContrasenia.FechaUltimaModificacion);
            Assert.AreEqual(DateTime.Now.Date, nuevaContrasenia.FechaUltimaModificacion.Date);
        }

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
        public void SePuedeBuscarUnaContrasenia()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia nuevaContrasenia = Gestor.Buscar(idNuevaContrasenia);
            Contrasenia buscada = Gestor.Buscar(nuevaContrasenia.Id);
            Assert.AreEqual(nuevaContrasenia.Sitio, buscada.Sitio);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void NoSePuedeBuscarUnaContraseniaQueNoExiste()
        {
           Gestor.Buscar(-200);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void NoSePuedeEliminarUnaContraseniaQueNoExisteEnRepositorio()
        {
           Gestor.Baja(-200);
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
                        
            Assert.AreEqual(1, idOtraContrasenia - idUnaContrasenia);
        }

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

        [TestMethod]
        public void SePuedeGenerarPasswordPorCaracteresConDistintosCaracteres()
        {
            Password nuevo = new Password("")
            {
                Largo = 13,
                Mayuscula = true,
                Minuscula = true,
                Numero = false,
                Especial = false
            };

            nuevo.GenerarPassword();

            Assert.AreEqual(13, nuevo.Clave.Length);
        }

        [TestMethod]
        public void SePuedeGenerarPasswordSoloMinusculas()
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


        [TestMethod]
        public void SePuedeGenerarPasswordSoloMayusculas()
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


        [TestMethod]
        public void SePuedeGenerarPasswordSoloNumeros()
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
        
        [TestMethod]
        public void SePuedeGenerarPasswordSoloConCaracteresEspeciales()
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

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedenGuardarDosPasswrodConMismoUsuarioYSitio()
        {
            Gestor.Alta(ContraseniaCompleta);
            Gestor.Alta(ContraseniaCompleta);
        }

        [TestMethod]
        public void SePuedenListarLasContrasenias()
        {
            int idNuevaContrasenia = Gestor.Alta(ContraseniaCompleta);
            Contrasenia unaC = Gestor.Buscar(idNuevaContrasenia);

            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Sitio = "otrositio.com",
                Categoria = new Categoria("Categoria"),
                Usuario = "usuario",
                Notas = "clave de netflix",
                FechaUltimaModificacion = DateTime.Now,
                Password = new Password("secreto")
            };

            Gestor.Alta(nuevaContrasenia);
                                    
            Assert.AreEqual(2, Gestor.ObtenerTodas().Count());
        }

              
        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void NoSeEncuentraContraseniaQueNoExiste()
        {
            Gestor.Buscar(-200);
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

        [TestMethod]
        public void SePuedeModificarPassword()
        {
            Gestor.Alta(ContraseniaCompleta);
            Contrasenia modificada =  new Contrasenia()
            {
                Sitio = ContraseniaCompleta.Sitio,
                Categoria = ContraseniaCompleta.Categoria,
                Usuario = ContraseniaCompleta.Usuario,
                Notas = ContraseniaCompleta.Notas,
                FechaUltimaModificacion = ContraseniaCompleta.FechaUltimaModificacion,
                Id = ContraseniaCompleta.Id,
                Password = new Password("Nuevo PASSWORD")
            };

            Gestor.ModificarContrasenia(modificada);
            Assert.AreEqual("Nuevo PASSWORD", ContraseniaCompleta.Password.Clave);

        }


    }
}
