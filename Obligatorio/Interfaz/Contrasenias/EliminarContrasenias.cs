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
            bSource.DataSource = this.Sesion.ListarContrasenias();
            this.cmbContrasenia.DataSource = bSource;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Contrasenia contraseniaSeleccionada = (Contrasenia)this.cmbContrasenia.SelectedItem;
                if (contraseniaSeleccionada == null)
                {
                    Alerta("Seleccione al menos una Contraseña", AlertaToast.enmTipo.Error);
                    return;
                }

                this.Sesion.BajaContrasenia(contraseniaSeleccionada.Id);
                Alerta("Contraseña Eliminada con éxito!!", AlertaToast.enmTipo.Exito);
                this.cmbContrasenia.Text = "";
                Refrescar();
            }
            catch (ExcepcionElementoNoExiste unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
            }
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
