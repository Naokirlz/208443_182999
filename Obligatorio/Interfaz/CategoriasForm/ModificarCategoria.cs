using Negocio;
using Negocio.Categorias;
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

namespace Interfaz
{
    public partial class ModificarCategoria : UserControl
    {
        public Sesion sis = Sesion.Singleton;

        public ModificarCategoria()
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
            string nombre = this.txtNuevoNombre.Text;
            try
            {
                Categoria aCambiar = (Categoria) this.cmbCategoria.SelectedItem;
                if (aCambiar == null)
                {
                    MessageBox.Show("Seleccione al menos una categoría");
                    return;
                }
                int id = aCambiar.Id;
                string nuevoNombre = this.txtNuevoNombre.Text;
                this.sis.GestorCategoria.Modificacion(id, nuevoNombre);
                this.txtNuevoNombre.Clear();
                Refrescar();
                MessageBox.Show("Categoría " + nuevoNombre + " fue modificada con éxito!!");
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                this.txtNuevoNombre.Focus();
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                this.txtNuevoNombre.Focus();
            }
        }
    }
}
