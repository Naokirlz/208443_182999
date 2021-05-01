using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Categorias;

namespace Negocio.TarjetaCreditos
{
    public class TarjetaCredito: IComparable<TarjetaCredito>
    {
       
        public int IdTarjeta { get; set; }
        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
        // ver si despues el tipo conviene que sea una clase
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string Codigo { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Nota { get; set; }

        public int CantidadVecesEncontradaVulnerable { get; set; }

        public int CompareTo(TarjetaCredito otraTarjeta)
        {
          return this.Categoria.Nombre.CompareTo(otraTarjeta.Categoria.Nombre);

        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
