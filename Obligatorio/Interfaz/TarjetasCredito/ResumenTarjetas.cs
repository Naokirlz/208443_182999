using Interfaz.Alertas;
using Negocio;
using Negocio.InterfacesGUI;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz.TarjetasCredito
{
    public partial class ResumenTarjetas : UserControl
    {
        private ITarjetaCredito Sesion = new TarjetaCreditoGUI();
        private IEnumerable<TarjetaCredito> Tarjetas;
        public ResumenTarjetas()
        {
            InitializeComponent();
            Tarjetas = Sesion.ObtenerTodasLasTarjetas();

            CargarColumnaBotones();

            CargarTabla();
        }

        private void CargarColumnaBotones()
        {
            DataGridViewButtonColumn columnaBotonVer = new DataGridViewButtonColumn();
            columnaBotonVer.Name = "columnaBotonVer";
            columnaBotonVer.Text = "Ver";
            columnaBotonVer.HeaderText = "Ver";
            int columnRevelarIndex = 5;
            if (dgvTarjetas.Columns["columnaBotonVer"] == null)
            {
                this.dgvTarjetas.Columns.Insert(columnRevelarIndex, columnaBotonVer);
                columnaBotonVer.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonModificar = new DataGridViewButtonColumn();
            columnaBotonModificar.Name = "columnaBotonModificar";
            columnaBotonModificar.Text = "Modificar";
            columnaBotonModificar.HeaderText = "Modificar";
            int columnModificarIndex = 6;
            if (dgvTarjetas.Columns["columnaBotonModificar"] == null)
            {
                this.dgvTarjetas.Columns.Insert(columnModificarIndex, columnaBotonModificar);
                columnaBotonModificar.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonEliminar = new DataGridViewButtonColumn();
            columnaBotonEliminar.Name = "columnaBotonEliminar";
            columnaBotonEliminar.Text = "Eliminar";
            columnaBotonEliminar.HeaderText = "Eliminar";
            int columnEliminarIndex = 7;
            if (dgvTarjetas.Columns["columnaBotonEliminar"] == null)
            {
                this.dgvTarjetas.Columns.Insert(columnEliminarIndex, columnaBotonEliminar);
                columnaBotonEliminar.UseColumnTextForButtonValue = true;
            }
        }

        private void CargarTabla()
        {
            dgvTarjetas.Rows.Clear();
            Tarjetas = Sesion.ObtenerTodasLasTarjetas();
            foreach (TarjetaCredito tarjeta in Tarjetas)
            {
                string[] fila = {
                    tarjeta.Id.ToString(),
                    tarjeta.Categoria.Nombre,
                    tarjeta.Nombre,
                    tarjeta.Tipo,
                    FormatoANumeroDeTarjeta(tarjeta.Numero),
                };
                this.dgvTarjetas.Rows.Add(fila);
            }
        }

        private string FormatoANumeroDeTarjeta(string numeroTarjeta)
        {
            string conFormato = "";
            int contador = 1;

            foreach(char caracter in numeroTarjeta)
            {
                if(contador > 12)
                {
                    conFormato += caracter;
                }
                else
                {
                    if (contador % 4 == 0)
                    {
                        conFormato += "X-";
                    }
                    else
                    {
                        conFormato += "X";
                    }
                }
                contador++;
            }

            return conFormato;
        }

        private void dgvTarjetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int id = Int32.Parse(dgvTarjetas.Rows[e.RowIndex].Cells[0].Value.ToString());
                TarjetaCredito tarjetaSeleccionada = Tarjetas.ToList().Find(c => c.Id == id);

                if (e.ColumnIndex == 5)
                {
                    MostrarTarjeta formMostrar = new MostrarTarjeta(tarjetaSeleccionada);
                }else if(e.ColumnIndex == 6)
                {
                    ModificarTarjeta formModificar = new ModificarTarjeta(tarjetaSeleccionada);
                    CargarTabla();
                }
                else if (e.ColumnIndex == 7)
                {
                    VentanaConfirmar frmConfirmar = new VentanaConfirmar(tarjetaSeleccionada.Id, Sesion.BajaTarjetaCredito)
                    {
                        MsgConfirmación = "Tarjeta Eliminada con éxito!!",
                        MsgPregunta = "Realmente desea eliminar la tarjeta??"
                    };
                    frmConfirmar.CargarFormulario();
                    CargarTabla();
                }
            }
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
