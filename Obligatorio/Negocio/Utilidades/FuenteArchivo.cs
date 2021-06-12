using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class FuenteArchivo : IFuente
    {
        public int BuscarPasswordOContraseniaEnFuente(string buscado)
        {
            int cantidad = 0;
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            List<string> strFiles = Directory.GetFiles(ruta, "*", SearchOption.AllDirectories).ToList();

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
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos\\" + nombrearchivo;
            System.IO.File.Copy(dataBreach, ruta, true);
        }
    }
}
