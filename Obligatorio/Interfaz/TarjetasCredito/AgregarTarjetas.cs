using Negocio.Clases;
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

namespace Interfaz.TarjetasCredito
{
    public partial class AgregarTarjetas : UserControl
    {
        public Sistema sis = Sistema.Singleton;
        public AgregarTarjetas()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.sis.GestorCategoria.ListarCategorias();
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
                DateTime vencimiento = this.monthCalendar1.SelectionStart;
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
                //clear todo
                Refrescar();
                //mensaje de exito
                //MessageBox.Show("Categoría " + nuevoNombre + " fue modificada con éxito!!");
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                //this.txtNuevoNombre.Focus();
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                //this.txtNuevoNombre.Focus();
            }
        }
    }
}
