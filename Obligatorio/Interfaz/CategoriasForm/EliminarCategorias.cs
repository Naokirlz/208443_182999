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
    public partial class EliminarCategorias : UserControl
    {
        public Sesion Sesion = Sesion.Singleton;
        public EliminarCategorias()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria aEliminar = (Categoria)this.cmbCategoria.SelectedItem;
                if (aEliminar == null)
                {
                    Alerta("Seleccione al menos una categoría", AlertaToast.enmTipo.Error);
                    return;
                }
                int id = aEliminar.Id;
                string nombre = aEliminar.Nombre;

                DialogResult respuesta = MessageBox.Show("Realmente desea eliminar la categoría " + nombre + "?", 
                    "Alerta", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    this.Sesion.BajaCategoria(id);
                    Refrescar();
                    Alerta("Categoría eliminada con éxito!!", AlertaToast.enmTipo.Exito);
                }
                
            }
            catch (ExcepcionElementoNoExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
            }
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje,tipo);
        }
    }
}
