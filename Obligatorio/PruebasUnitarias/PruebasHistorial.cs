using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.TarjetaCreditos;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasHistorial
    {
        Sesion sesionPrueba;
        FuenteLocal Fuente;
        private TarjetaCredito nuevoTarjeta;
        private Contrasenia pruebaContrasenia;


        [TestInitialize]
        public void InicializarPruebas()
        {

            sesionPrueba = Sesion.ObtenerInstancia();
            sesionPrueba.VaciarDatosPrueba();
            sesionPrueba.GuardarPrimerPassword("secreto");
            sesionPrueba.Login("secreto");
            int id = sesionPrueba.AltaCategoria("Cosas");
            Categoria nuevaCategoriaPrueba = sesionPrueba.BuscarCategoriaPorId(id);

            this.nuevoTarjeta = new TarjetaCredito()
            {
                Categoria = nuevaCategoriaPrueba,
                Nombre = "PruebaNombre",
                Tipo = "PruebaTipo",
                Numero = "1234123412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional",

            };

            this.pruebaContrasenia = new Contrasenia()
            {
                Sitio = "deremate.com",
                Usuario = "fedex",
                Password = new Password("dalevo111!!!"),
                Categoria = nuevaCategoriaPrueba,
                Notas = "Sin"
            };

            sesionPrueba.AltaTarjetaCredito(nuevoTarjeta);
            sesionPrueba.AltaContrasenia(pruebaContrasenia);
            sesionPrueba.FuenteLocal.CrearDataBreach("dalevo111!!!\n1234123412341234");

        }

        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesionPrueba.VaciarDatosPrueba();
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (Directory.Exists(rutaDirectorio))
            {
                List<string> strFiles = Directory.GetFiles(rutaDirectorio, "*", SearchOption.AllDirectories).ToList();

                foreach (string fichero in strFiles)
                {
                    File.Delete(fichero);
                }
            }

        }


        [TestMethod]
        public void SePuedeGuardiarHistorial2Tarjeta()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;

            HistorialTarjetas nuevo = new HistorialTarjetas();
            nuevo.NumeroTarjeta = "1234123412341234";
            historial.tarjetasVulnerables.Add(nuevo);

            HistorialTarjetas nuevo2 = new HistorialTarjetas();
            nuevo2.NumeroTarjeta = "1234123412349999";
            historial.tarjetasVulnerables.Add(nuevo2);
            
            DateTime registroHistorial = historial.Guardar();

            Assert.IsNotNull(registroHistorial);

        }



    }

}
