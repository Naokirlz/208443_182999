using Negocio;
using Negocio.Categorias;
using Negocio.Excepciones;
using Negocio.TarjetaCreditos;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Interfaz.TarjetasCredito
{
    public partial class ModificarTarjetas : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;

        public ModificarTarjetas()
        {
            InitializeComponent();
            Refrescar();
        }
        private void Refrescar()
        {
            BindingList<TarjetaCredito> bindinglist = new BindingList<TarjetaCredito>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasTarjetas();
            this.cmbTarjetas.DataSource = bSource;

            BindingList<Categoria> bindinglist2 = new BindingList<Categoria>();
            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource2;

            CargarDatosTarjeta();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TarjetaCredito tarjetaSeleccionada = (TarjetaCredito)this.cmbTarjetas.SelectedItem;
                if (tarjetaSeleccionada == null)
                {
                    Alerta("Seleccione al menos una Tarjeta de Crédito", AlertaToast.enmTipo.Error);
                    return;
                }

                Categoria categoria = (Categoria)this.cmbCategoria.SelectedItem;
                if (categoria == null)
                {
                    Alerta("Seleccione al menos una categoría", AlertaToast.enmTipo.Error);
                    return;
                }

                string nombre = this.txtNombre.Text;
                string tipo = this.txtTipo.Text;
                string numero = this.txtNumero.Text;
                string codigo = this.txtCodigo.Text;
                string notas = this.txtNotas.Text;
                DateTime vencimiento = this.dtpVencimiento.Value;
                int id = tarjetaSeleccionada.Id;
                numero = numero.Replace(" ", "");

                TarjetaCredito tarjetaAModificar = new TarjetaCredito()
                {
                    Id = id,
                    Nombre = nombre,
                    Categoria = categoria,
                    Tipo = tipo,
                    Numero = numero,
                    Codigo = codigo,
                    Nota = notas,
                    Vencimiento = vencimiento
                };

                this.Sesion.ModificarTarjeta(tarjetaAModificar);
                Alerta("Tarjeta modificada con éxito!!", AlertaToast.enmTipo.Exito);
                LimpiarCampos();
                Refrescar();
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
            }
            catch (ExcepcionNumeroNoValido unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
            }
        }

        private void LimpiarCampos()
        {
            this.txtCodigo.Text = "";
            this.txtTipo.Text = "";
            this.txtNombre.Text = "";
            this.txtNumero.Text = "";
            this.txtNotas.Text = "";
            this.dtpVencimiento.Value = DateTime.Now;
        }

        private void cmbTarjeta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarDatosTarjeta();
        }

        private void CargarDatosTarjeta()
        {
            TarjetaCredito tarjetaSeleccionada = (TarjetaCredito)this.cmbTarjetas.SelectedItem;
            if (tarjetaSeleccionada != null)
            {
                this.txtCodigo.Text = tarjetaSeleccionada.Codigo;
                this.cmbCategoria.SelectedItem = tarjetaSeleccionada.Categoria;
                this.txtNombre.Text = tarjetaSeleccionada.Nombre;
                this.txtTipo.Text = tarjetaSeleccionada.Tipo;
                this.txtNumero.Text = tarjetaSeleccionada.Numero;
                this.txtCodigo.Text = tarjetaSeleccionada.Codigo;
                this.txtNotas.Text = tarjetaSeleccionada.Nota;
                this.dtpVencimiento.Value = tarjetaSeleccionada.Vencimiento;
            }
        }

        private void cmbContrasenias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosTarjeta();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(this.Text + e.KeyChar, "^[0-9]*$")) e.Handled = true;
            else base.OnKeyPress(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(this.Text + e.KeyChar, "^[0-9]*$")) e.Handled = true;
            else base.OnKeyPress(e);
        }

        private void txtNumero_Click(object sender, EventArgs e)
        {
            this.txtNumero.Select(0, 0);
        }

        private void txtCodigo_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Select(0, 0);
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
