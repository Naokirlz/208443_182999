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
        //no se puede guardar una contraseña sin sitio
        //no se puede guardar una contraseña sin usuario
        //no se puede guardar una contraseña sin password
        //no se puede guardar una contraseña sin categoria
        //no se puede guardar una contraseña con categoria que no existe
        //no se puede guardar una contraseña sin fecha de modificacion
        //se puede cambiar el sitio
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
    }
}
