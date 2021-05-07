using Negocio;
using Negocio.Categorias;
using Negocio.TarjetaCreditos;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Interfaz.TarjetasCredito
{
    public partial class AgregarTarjetas : UserControl
    {
        public Sesion sis = Sesion.Singleton;
        public AgregarTarjetas()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.sis.GestorCategoria.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = (Categoria)this.cmbCategoria.SelectedItem;
                if (categoria == null)
                {
                    MessageBox.Show("Seleccione al menos una categoría");
                    return;
                }
                string nombre = this.txtNombre.Text;
                string tipo = this.txtTipo.Text;
                string numero = this.txtNumero.Text;
                string codigo = this.txtCodigo.Text;
                string notas = this.txtNotas.Text;
                DateTime vencimiento = this.dtpVencimiento.Value;

                numero = numero.Replace(" ", "");

                TarjetaCredito nuevaTarjeta = new TarjetaCredito() { 
                    Nombre = nombre,
                    Categoria = categoria,
                    Tipo = tipo,
                    Numero = numero,
                    Codigo = codigo,
                    Nota = notas,
                    Vencimiento = vencimiento
                };
                this.sis.GestorTarjetaCredito.Alta(nuevaTarjeta);
                MessageBox.Show("Tarjeta " + nuevaTarjeta + " fue guardada con éxito!!");
                LimpiarCampos();
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
            }
        }
        private void LimpiarCampos()
        {
            this.txtNumero.Text = "";
            this.txtTipo.Text = "";
            this.txtNombre.Text = "";
            this.txtCodigo.Text = "";
            this.txtNotas.Text = "";
            this.dtpVencimiento.Value = DateTime.Now;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(this.Text + e.KeyChar, "^[0-9]*$"))
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyPress(e);
            }
        }

        private void txtCodigo_Click(object sender, EventArgs e)
        {
            this.txtNumero.Select(0, 0);
        }

        private void txtNumero_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Select(0, 0);
        }

        private void txtCodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(this.Text + e.KeyChar, "^[0-9]*$")) e.Handled = true;
            else base.OnKeyPress(e);
        }
    }
}
