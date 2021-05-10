using Negocio;
using Negocio.Categorias;
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
    public partial class MostrarTarjeta : Form
    {
        private TarjetaCredito TarjetaDeCredito;
        private Sesion Sesion;
        private enmAccion Accion;
        public MostrarTarjeta(TarjetaCredito tarjeta)
        {
            InitializeComponent();
            Sesion = Sesion.Singleton;
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;

            this.Opacity = 0.0;
            TarjetaDeCredito = tarjeta;
            this.cmbCategoria.SelectedItem = TarjetaDeCredito.Categoria;
            this.txtCodigo.Text = TarjetaDeCredito.Codigo;
            this.txtNombre.Text = TarjetaDeCredito.Nombre;
            this.txtTipo.Text = TarjetaDeCredito.Tipo;
            this.txtNumero.Text = TarjetaDeCredito.Numero;
            this.txtCodigo.Text = TarjetaDeCredito.Codigo;
            this.txtNotas.Text = TarjetaDeCredito.Nota;
            this.dtpVencimiento.Value = TarjetaDeCredito.Vencimiento;

            this.Show();
            this.Accion = enmAccion.iniciar;
            timMuestraTarjeta.Interval = 1;
            timMuestraTarjeta.Start();
        }

        public enum enmAccion
        {
            esperar,
            iniciar,
            cerrar
        }

        private void timMuestraTarjeta_Tick(object sender, EventArgs e)
        {
            switch (this.Accion)
            {
                case enmAccion.esperar:
                    timMuestraTarjeta.Interval = 30000;
                    Accion = enmAccion.cerrar;
                    break;
                case enmAccion.iniciar:
                    timMuestraTarjeta.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.Opacity == 1.0)
                    {
                        Accion = enmAccion.esperar;
                    }
                    break;
                case enmAccion.cerrar:
                    timMuestraTarjeta.Interval = 1;
                    this.Opacity -= 0.1;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            timMuestraTarjeta.Interval = 1;
            Accion = enmAccion.cerrar;
        }
    }
}
