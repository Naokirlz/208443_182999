using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class TarjetaCredito
    {
        private static List<TarjetaCredito> tarjetas = new List<TarjetaCredito>();

        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
        // ver si despues el tipo conviene que sea una clase
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public int Codigo { get; set; }
        public DateTime Vencimiento { get; set; }
        public String Nota { get; set; }


        public static TarjetaCredito Alta(TarjetaCredito nueva)
        {
            // hago los controles
            tarjetas.Add(nueva);
            // si agrego y si no tiro exception
            return nueva;

        }

    }
}
