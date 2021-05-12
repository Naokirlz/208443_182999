using Negocio;
using Negocio.Categorias;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Interfaz.Categorias
{
    public partial class EliminarCategorias : UserControl
    {
        public Sesion Sesion = Sesion.ObtenerInstancia();
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
            Categoria aEliminar = (Categoria)this.cmbCategoria.SelectedItem;
            if (aEliminar == null)
            {
                Alerta("Seleccione al menos una categoría", AlertaToast.enmTipo.Error);
                return;
            }
            int id = aEliminar.Id;

            VentanaConfirmar frmConfirmar = new VentanaConfirmar(id, Sesion.BajaCategoria)
            {
                MsgConfirmación = "Categoría eliminada con éxito!!",
                MsgPregunta = "Desea eliminar la categoría??"
            };

            frmConfirmar.CargarFormulario();
            Refrescar();
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje,tipo);
        }
    }
}
