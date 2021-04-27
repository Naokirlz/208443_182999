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
    public partial class AgregarCategoria : UserControl
    {
        public Sistema sis = Sistema.Singleton;
         
        public AgregarCategoria()
        {
            InitializeComponent();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            try
            {
                this.sis.GestorCategoria.Alta(nombre);
                this.txtNombre.Clear();
                MessageBox.Show("Categoría " + nombre + " fue creada con éxito!!");
            }
            catch (ExcepcionElementoYaExiste unaExcepcion){
                MessageBox.Show(unaExcepcion.Message);
                this.txtNombre.Focus();
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                this.txtNombre.Focus();
            }
            
        }
    }
}
