using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Negocio.DataBreaches
{
    public class FuenteArchivo : IFuente
    {
        public string RutaDirectorio { get; set; }
        public FuenteArchivo()
        {
            RutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (!Directory.Exists(this.RutaDirectorio))
            {
                Directory.CreateDirectory(RutaDirectorio);
            }
        }

        public int BuscarPasswordOContraseniaEnFuente(string buscado)
        {
            int cantidad = 0;
            List<string> strFiles = Directory.GetFiles(RutaDirectorio, "*", SearchOption.AllDirectories).ToList();

            foreach (string fichero in strFiles)
            {
                List<string> lineas = File.ReadAllLines(fichero).ToList();
                foreach (var item in lineas)
                {
                    if (item.Equals(buscado)) cantidad++;
                    
                }
            }
            return cantidad;
        }

        public void CrearDataBreach(string dataBreach)
        {
            string[] rutaDetalle = dataBreach.Split('\\').ToArray();
            string nombrearchivo = rutaDetalle[rutaDetalle.Length - 1];
            string ruta = RutaDirectorio + "\\" + nombrearchivo;
            System.IO.File.Copy(dataBreach, ruta, true);
        }
    }
}
