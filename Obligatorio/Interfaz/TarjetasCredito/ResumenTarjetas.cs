using Negocio;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.TarjetasCredito
{
    public partial class ResumenTarjetas : UserControl
    {
        Sesion Sesion = Sesion.Singleton;
        public ResumenTarjetas()
        {
            InitializeComponent();
            IEnumerable<TarjetaCredito> tarjetas = Sesion.GestorTarjetaCredito.ObtenerTodas();
            foreach(TarjetaCredito tarjeta in tarjetas)
            {
                string[] fila = { 
                    tarjeta.Categoria.Nombre,
                    tarjeta.Nombre,
                    tarjeta.Tipo,
                    FormatoANumeroDeTarjeta(tarjeta.Numero),
                    tarjeta.Vencimiento.ToShortDateString(),
                };
                this.dgvTarjetas.Rows.Add(fila);
            }
        }

        private string FormatoANumeroDeTarjeta(string numeroTarjeta)
        {
            string conFormato = "";
            int contador = 1;

            foreach(char caracter in numeroTarjeta)
            {
                if(contador > 12)
                {
                    conFormato += caracter;
                }
                else
                {
                    if (contador % 4 == 0)
                    {
                        conFormato += "X-";
                    }
                    else
                    {
                        conFormato += "X";
                    }
                }
                contador++;
            }

            return conFormato;
        }
    }
}
