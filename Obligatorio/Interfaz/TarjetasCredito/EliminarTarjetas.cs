using Negocio;
using Negocio.Utilidades;



namespace Interfaz.TarjetasCredito
{
    public partial class EliminarTarjetas : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        public EliminarTarjetas()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Refrescar()
        {
            BindingList<TarjetaCredito> bindinglist = new BindingList<TarjetaCredito>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasTarjetas();
            this.cmbTarjeta.DataSource = bSource;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TarjetaCredito tarjetaSeleccionada = (TarjetaCredito)this.cmbTarjeta.SelectedItem;
            if (tarjetaSeleccionada == null)
            {
                Alerta("Seleccione al menos una Tarjeta de Crédito", AlertaToast.enmTipo.Error);
                return;
            }

            VentanaConfirmar frmConfirmar = new VentanaConfirmar(tarjetaSeleccionada.Id, Sesion.BajaTarjetaCredito)
            {
                MsgConfirmación = "Tarjeta Eliminada con éxito!!",
                MsgPregunta = "Realmente desea eliminar la tarjeta??"
            };
            frmConfirmar.CargarFormulario();

            Refrescar();
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
