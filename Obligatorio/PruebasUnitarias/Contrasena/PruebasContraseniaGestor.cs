﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias.Contrasena
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
            Contrasenia nuevaContrasena = new Contrasenia() { 
                //CategoriaPass = categoria,
                Usuario = "usuario",
                Sitio = "netflix",
                Notas = "clave de netflix",
                //FechaUltimaModificacion = DateTime.Now,
                Password = "secreto"
            };
            nuevaContrasena.SetCategoriaPass(categoria);
            nuevaContrasena.SetFechaUltimaModificacion(DateTime.Now);
            Gestor.Alta(nuevaContrasena);
            List<Contrasenia> contrasenias = Gestor.ListarContrasenias();
            bool existe = contrasenias.Any(c => c.Usuario == nuevaContrasena.Usuario && c.Sitio == nuevaContrasena.Sitio);
            Assert.IsTrue(existe);
        }
    }
}
