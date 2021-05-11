using Negocio;
using Negocio.Categorias;
using Negocio.TarjetaCreditos;
using Negocio.Utilidades;
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
        public Sesion Sesion = Sesion.Singleton;
        public AgregarTarjetas()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
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
                Sesion.AltaTarjetaCredito(nuevaTarjeta);
                Alerta("Tarjeta guardada con éxito!!", AlertaToast.enmTipo.Exito);
                LimpiarCampos();
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
            this.txtNumero.Text = "";
            this.txtTipo.Text = "";
            this.txtNombre.Text = "";
            this.txtCodigo.Text = "";
            this.txtNotas.Text = "";
            this.dtpVencimiento.Value = DateTime.Now;
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

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
