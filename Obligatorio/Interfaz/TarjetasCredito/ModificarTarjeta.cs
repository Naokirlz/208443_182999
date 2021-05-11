using Negocio;
using Negocio.Categorias;
using Negocio.Excepciones;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.TarjetasCredito
{
    public partial class ModificarTarjeta : Form
    {
        private Sesion Sesion = Sesion.Singleton;
        private TarjetaCredito tarjetaSeleccionada;

        public ModificarTarjeta(TarjetaCredito tarjetaSeleccionada)
        {
            InitializeComponent();
            this.tarjetaSeleccionada = tarjetaSeleccionada;

            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;

            this.cmbCategoria.SelectedItem = tarjetaSeleccionada.Categoria;
            this.txtCodigo.Text = tarjetaSeleccionada.Codigo;
            this.txtNombre.Text = tarjetaSeleccionada.Nombre;
            this.txtTipo.Text = tarjetaSeleccionada.Tipo;
            this.txtNumero.Text = tarjetaSeleccionada.Numero;
            this.txtCodigo.Text = tarjetaSeleccionada.Codigo;
            this.txtNotas.Text = tarjetaSeleccionada.Nota;
            this.dtpVencimiento.Value = tarjetaSeleccionada.Vencimiento;

            this.ShowDialog();
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
                this.Close();
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

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
