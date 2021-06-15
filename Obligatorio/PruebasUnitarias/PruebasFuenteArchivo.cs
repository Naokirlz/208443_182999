using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.DataBreaches;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasFuenteArchivo
    {
        IVulnerablidades sesionPrueba;
        [TestCleanup]
        public void LimpiarPruebas()
        {
            sesionPrueba = IVulnerablidades.ObtenerInstancia();
            sesionPrueba.VaciarDatosPrueba();
        }

        [TestMethod]
        public void SePuedeCopiarUnArchivoDeFileSystemALaCarpetaDeFuentes()
        {
            string rutaDirectorioOriginal = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales";
            string rutaArchivoOriginal = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales\\Fuente.txt";
            if (!Directory.Exists(rutaDirectorioOriginal))
            {
                Directory.CreateDirectory(rutaDirectorioOriginal);
            }
            using (StreamWriter sw = File.CreateText(rutaArchivoOriginal)){}

            string rutaDestino = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos\\Fuente.txt";
            FuenteArchivo nueva = new FuenteArchivo();
            nueva.CrearDataBreach(rutaArchivoOriginal);

            Assert.IsTrue(File.Exists(rutaDestino));
        }

        [TestMethod]
        public void SePuedeLeerUnArchivo()
        {
            string rutaDirectorioOriginal = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales";
            string rutaArchivoOriginal = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales\\Fuente.txt";
            if (!Directory.Exists(rutaDirectorioOriginal))
            {
                Directory.CreateDirectory(rutaDirectorioOriginal);
            }
            using (StreamWriter sw = File.CreateText(rutaArchivoOriginal))
            {
                sw.WriteLine("55555");
                sw.WriteLine("sssssss");
                sw.WriteLine("55555");
            }
            FuenteArchivo nueva = new FuenteArchivo();
            string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales\\Fuente.txt";
            nueva.CrearDataBreach(rutaArchivo);
            int cantidad = nueva.BuscarPasswordOContraseniaEnFuente("55555");
            Assert.IsTrue(cantidad == 2);
        }

        [TestMethod]
        public void SePuedenLeerDosArchivos()
        {
            string rutaDirectorioOriginal = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales";
            string rutaArchivoOriginal = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales\\Fuente.txt";
            string rutaArchivo2Original = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosOriginales\\Fuente2.txt";
            if (!Directory.Exists(rutaDirectorioOriginal))
            {
                Directory.CreateDirectory(rutaDirectorioOriginal);
            }
            using (StreamWriter sw = File.CreateText(rutaArchivoOriginal))
            {
                sw.WriteLine("55555");
                sw.WriteLine("sssssss");
                sw.WriteLine("55555");
            }
            using (StreamWriter sw = File.CreateText(rutaArchivo2Original))
            {
                sw.WriteLine("fffff");
                sw.WriteLine("sssssss");
                sw.WriteLine("55555");
            }
            FuenteArchivo nueva = new FuenteArchivo();
            nueva.CrearDataBreach(rutaArchivoOriginal);
            nueva.CrearDataBreach(rutaArchivo2Original);
            int cantidad = nueva.BuscarPasswordOContraseniaEnFuente("55555");
            Assert.IsTrue(cantidad == 3);
        }

        [TestMethod]
        public void CreaDirectorioSiNoExisteAlCrearFuenteArchivo()
        {
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            Directory.Delete(ruta);
            Assert.IsFalse(Directory.Exists(ruta));
            FuenteArchivo nuevo = new FuenteArchivo();
            Assert.IsTrue(Directory.Exists(ruta));

        }

    }
}
