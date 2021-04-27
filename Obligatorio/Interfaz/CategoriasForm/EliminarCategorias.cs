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
    public partial class EliminarCategorias : UserControl
    {
        public Sistema sis = Sistema.Singleton;
        public EliminarCategorias()
        {
            InitializeComponent();
            Refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria aEliminar = (Categoria)this.cmbCategoria.SelectedItem;
                if (aEliminar == null)
                {
                    MessageBox.Show("Seleccione al menos una categoría");
                    return;
                }
                int id = aEliminar.Id;
                string nombre = aEliminar.Nombre;

                this.sis.GestorCategoria.Baja(id);
                Refrescar();
                MessageBox.Show("Categoría " + nombre + " fue eliminada con éxito!!");
            }
            catch (ExcepcionElementoNoExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
            }
        }

        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.sis.GestorCategoria.ListarCategorias();
            this.cmbCategoria.DataSource = bSource;
        }
    }
}
