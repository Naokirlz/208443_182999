using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasFuenteArchivo
    {

        [TestInitialize]
        public void InicializarPruebas()
        {
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            List<string> strFiles = Directory.GetFiles(ruta, "*", SearchOption.AllDirectories).ToList();

            foreach (string fichero in strFiles)
            {
                File.Delete(fichero);
            }
        }


        [TestMethod]
        public void SePuedeCopiarUnArchivoDeFileSystemALaCarpetaDeFuentes()
        {
            string ruta= AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales\\Fuente.txt";
            string rutaDestino = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos\\Fuente.txt";
            FuenteArchivo nueva = new FuenteArchivo();
            nueva.CrearDataBreach(ruta);
            Assert.IsTrue(File.Exists(rutaDestino));
    
        }

        [TestMethod]
        public void SePuedeLeerUnArchivo()
        {
            FuenteArchivo nueva = new FuenteArchivo();
            string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales\\Fuente.txt";
            nueva.CrearDataBreach(rutaArchivo);
            int cantidad = nueva.BuscarPasswordOContraseniaEnFuente("55555");
            Assert.IsTrue(cantidad > 0);
            



        }



    }
}
