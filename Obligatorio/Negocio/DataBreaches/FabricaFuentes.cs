using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Negocio.DataBreaches
{
    public class FabricaFuentes
    {
        private FuenteLocal fuenteLocal;
        private FuenteArchivo fuenteArchivo;
        private List<IFuente> fuentes;

        public FabricaFuentes()
        {
            this.fuentes = new List<IFuente>();
            this.fuenteLocal = new FuenteLocal();
            this.fuenteArchivo = new FuenteArchivo();
        }
        public List<IFuente> FabricarFuentes()
        {
            this.fuentes = new List<IFuente>();

            this.fuenteLocal = new FuenteLocal();
            this.fuenteArchivo = new FuenteArchivo();
            fuentes.Add(fuenteLocal);
            fuentes.Add(fuenteArchivo);

            return fuentes;
        }

        private void LimpiarFuenteArchivo()
        {
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
        private void LimpiarFuenteLocal()
        {
            fuentes.Remove(fuenteLocal);
            fuenteLocal = new FuenteLocal();
            fuentes.Add(this.fuenteLocal);
        }

        public void CrearDataBreach(IFuente fuente, string cadena)
        {
            foreach(IFuente fue in fuentes)
            {
                if(fue.GetType() == fuente.GetType())
                {
                    fue.CrearDataBreach(cadena);
                }
            }
        }
        public void LimpiarFuentes()
        {
            LimpiarFuenteArchivo();
            LimpiarFuenteLocal();
        }
    }
}
