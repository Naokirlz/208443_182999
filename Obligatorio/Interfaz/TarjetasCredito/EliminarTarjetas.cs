using Negocio;
using Negocio.Excepciones;
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
    public partial class EliminarTarjetas : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        public EliminarTarjetas()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<TarjetaCredito> bindinglist = new BindingList<TarjetaCredito>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.GestorTarjetaCredito.ObtenerTodas();
            this.cmbTarjeta.DataSource = bSource;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                TarjetaCredito tarjetaSeleccionada = (TarjetaCredito)this.cmbTarjeta.SelectedItem;
                if (tarjetaSeleccionada == null)
                {
                    MessageBox.Show("Seleccione al menos una Tarjeta de Crédito");
                    return;
                }

                this.Sesion.BajaTarjetaCredito(tarjetaSeleccionada.Id);
                MessageBox.Show("Tarjeta Eliminada con éxito!!");
                this.cmbTarjeta.Text = "";
                Refrescar();
            }
            catch (ExcepcionElementoNoExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
            }
        }
    }
}
