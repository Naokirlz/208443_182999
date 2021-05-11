using Negocio;
using Negocio.Categorias;
using Negocio.Utilidades;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ModificarCategoria : UserControl
    {
        public Sesion sesion = Sesion.Singleton;

        public ModificarCategoria()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNuevoNombre.Text;
            try
            {
                Categoria aCambiar = (Categoria)this.cmbCategoria.SelectedItem;
                if (aCambiar == null)
                {
                    Alerta("Seleccione al menos una categoría", AlertaToast.enmTipo.Error);
                    return;
                }
                int id = aCambiar.Id;
                string nuevoNombre = this.txtNuevoNombre.Text;
                this.sesion.ModificarCategoria(id, nuevoNombre);
                this.txtNuevoNombre.Clear();
                Refrescar();
                Alerta("Categoría modificada con éxito!!", AlertaToast.enmTipo.Exito);
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
                this.txtNuevoNombre.Focus();
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
                this.txtNuevoNombre.Focus();
            }
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
