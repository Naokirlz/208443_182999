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
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (!Directory.Exists(rutaDirectorio))
            {
                Directory.CreateDirectory(rutaDirectorio);
            }
            int cantidad = 0;
            List<string> strFiles = Directory.GetFiles(rutaDirectorio, "*", SearchOption.AllDirectories).ToList();

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
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (!Directory.Exists(rutaDirectorio))
            {
                Directory.CreateDirectory(rutaDirectorio);
            }
            string[] rutaDetalle = dataBreach.Split('\\').ToArray();
            string nombrearchivo = rutaDetalle[rutaDetalle.Length - 1];
            string ruta = rutaDirectorio + "\\" + nombrearchivo;
            System.IO.File.Copy(dataBreach, ruta, true);
        }
    }
}
