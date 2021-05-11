using Negocio;
using Negocio.Utilidades;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.TarjetasCredito
{
    public partial class ResumenTarjetas : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        private IEnumerable<TarjetaCredito> Tarjetas;
        public ResumenTarjetas()
        {
            InitializeComponent();
            Tarjetas = Sesion.ObtenerTodasLasTarjetas();

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

            CargarTabla();
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
                string id = dgvTarjetas.Rows[e.RowIndex].Cells[0].Value.ToString();
                TarjetaCredito tarjetaSeleccionada = null;
                foreach (TarjetaCredito tarjeta in Tarjetas)
                {
                    if (tarjeta.Id.ToString() == id) tarjetaSeleccionada = tarjeta;
                }
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
                    try
                    {
                        DialogResult respuesta = MessageBox.Show("Realmente desea eliminar la tarjeta?",
                            "Alerta",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.Yes)
                        {
                            this.Sesion.BajaTarjetaCredito(tarjetaSeleccionada.Id);
                            CargarTabla();
                            Alerta("Tarjeta eliminada con éxito!!", AlertaToast.enmTipo.Exito);
                        }
                    }
                    catch (ExcepcionElementoNoExiste unaExcepcion)
                    {
                        Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
                    }
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
