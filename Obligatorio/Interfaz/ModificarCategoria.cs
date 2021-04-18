using Negocio;
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

namespace Interfaz
{
    public partial class ModificarCategoria : UserControl
    {
        public GestorCategorias GestorCategorias;

        public ModificarCategoria(GestorCategorias gestorCategorias)
        {
            InitializeComponent();
            this.GestorCategorias = gestorCategorias;
            this.cmbCategoria.DataSource = this.GestorCategorias.Repositorio.Categorias;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNuevoNombre.Text;
            try
            {
                Categoria aCambiar = (Categoria) this.cmbCategoria.SelectedItem;
                int id = aCambiar.Id;
                string nuevoNombre = this.txtNuevoNombre.Text;
                this.GestorCategorias.ModificarCategoria(id, nuevoNombre);
                this.txtNuevoNombre.Clear();
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
