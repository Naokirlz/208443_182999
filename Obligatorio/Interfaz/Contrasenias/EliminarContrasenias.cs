using Negocio;
using Negocio.Contrasenias;
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

namespace Interfaz.Contrasenias
{
    public partial class EliminarContrasenias : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        public EliminarContrasenias()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<Contrasenia> bindinglist = new BindingList<Contrasenia>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.GestorContrasenia.ListarContrasenias();
            this.cmbContrasenia.DataSource = bSource;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Contrasenia contraseniaSeleccionada = (Contrasenia)this.cmbContrasenia.SelectedItem;
                if (contraseniaSeleccionada == null)
                {
                    MessageBox.Show("Seleccione al menos una Contraseña");
                    return;
                }

                this.Sesion.GestorContrasenia.Baja(contraseniaSeleccionada.Id);
                MessageBox.Show("Contraseña Eliminada con éxito!!");
                this.cmbContrasenia.Text = "";
                Refrescar();
            }
            catch (ExcepcionElementoNoExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
            }
        }
    }
}
