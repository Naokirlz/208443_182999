using Negocio;
using Negocio.Contrasenias;
using Negocio.TarjetaCreditos;
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
using Negocio.DataBreaches;

namespace Interfaz.Vulnerabilidades
{
    public partial class HistorialVulnerabilidades : UserControl
    {
        IVulnerablidades Sesion = IVulnerablidades.ObtenerInstancia();
        int HistorialSeleccionado;
        public HistorialVulnerabilidades()
        {
            InitializeComponent();
            this.dgvDetalleContrasenia.Visible = false;
            this.dgvDetalleTarjeta.Visible = false;
            CargarTablaHistorial();
        }
        private void GenerarColumnaDeBotones()
        {
            DataGridViewButtonColumn columnaBotonVer = new DataGridViewButtonColumn();
            columnaBotonVer.Name = "Ver";
            columnaBotonVer.Text = "Ver";
            int columnIndex = 2;
            if (dgvHistorial.Columns["Ver"] == null)
            {
                this.dgvHistorial.Columns.Insert(columnIndex, columnaBotonVer);
                columnaBotonVer.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonModificar = new DataGridViewButtonColumn();
            columnaBotonModificar.Name = "Modificar";
            columnaBotonModificar.Text = "Modificar";
            columnaBotonModificar.HeaderText = "Acciones";
            int columnModificarIndex = 4;
            if (dgvDetalleContrasenia.Columns["Acciones"] == null)
            {
                this.dgvDetalleContrasenia.Columns.Insert(columnModificarIndex, columnaBotonModificar);
            }
        }

        private void CargarTablaHistorial()
        {
            IEnumerable<Historial> historiales = Sesion.ObtenerTodasLosHistoriales();
            this.dgvHistorial.Rows.Clear();
            foreach (Historial historial in historiales)
            {
                string[] fila = {
                    historial.HistorialId.ToString(),
                    historial.Fecha.ToString()
                };
                this.dgvHistorial.Rows.Add(fila);
            }
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 2)
                {
                    this.dgvDetalleTarjeta.Visible = true;
                    this.dgvDetalleContrasenia.Visible = true;
                    this.dgvHistorial.Visible = false;
                    this.btnVolver.Visible = true;
                    int historial = Convert.ToInt32(dgvHistorial.Rows[e.RowIndex].Cells[0].Value.ToString());
                    HistorialSeleccionado = historial;
                    CargarTablaContrasenias(historial);
                    CargarTablaTarjetas(historial);
                }
            }
        }

        private void CargarTablaContrasenias(int historial)
        {
            IEnumerable<HistorialContrasenia> contrasenias = Sesion.DevolverContraseniasVulnerables(historial);

            this.dgvDetalleContrasenia.Rows.Clear();
            foreach (HistorialContrasenia histoCon in contrasenias)
            {
                Contrasenia contrasenia = Sesion.BuscarContrasenia(histoCon.ContraseniaId);
                string[] fila = {
                    //id - sitio - usuario - clave - acciones
                    histoCon.ContraseniaId.ToString(),
                    contrasenia.Sitio,
                    contrasenia.Usuario,
                    histoCon.Clave // el boton cambia segun la clave
                };
                this.dgvDetalleContrasenia.Rows.Add(fila);
            }
        }

        private void CargarTablaTarjetas(int historial)
        {
            IEnumerable<HistorialTarjetas> tarjetas = Sesion.DevolverTarjetasVulnerables(historial);

            this.dgvDetalleTarjeta.Rows.Clear();
            foreach (HistorialTarjetas histoTar in tarjetas)
            {
                string[] fila = {
                    FormatoANumeroDeTarjeta(histoTar.NumeroTarjeta),
                };
                this.dgvDetalleTarjeta.Rows.Add(fila);
            }
        }

        private void dgvDetalleContrasenia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == this.dgvDetalleContrasenia.NewRowIndex)
                return;

            if (e.ColumnIndex == this.dgvDetalleContrasenia.Columns["Acciones"].Index)
            {
                int contraseniaId = Convert.ToInt32(dgvDetalleContrasenia.Rows[e.RowIndex].Cells["ContraseniaId"].Value.ToString());
                string claveAnterior = dgvDetalleContrasenia.Rows[e.RowIndex].Cells["ClaveFiltrada"].Value.ToString();

                Contrasenia contrasenia = Sesion.BuscarContrasenia(contraseniaId);

                if (contrasenia.Password.Clave == claveAnterior)
                    dgvDetalleContrasenia.Rows[e.RowIndex].Cells["Acciones"].Value = "Modificar";
                else
                {
                    dgvDetalleContrasenia.Rows[e.RowIndex].Cells["Acciones"].Value = "Cambiado";
                }
            }
        }
        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.dgvDetalleTarjeta.Visible = false;
            this.dgvDetalleContrasenia.Visible = false;
            this.dgvHistorial.Visible = true;
            this.btnVolver.Visible = false;
        }

        private void dgvDetalleContrasenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {
                    string valorBtn = dgvDetalleContrasenia.Rows[e.RowIndex].Cells[4].Value.ToString();
                    if (valorBtn.Equals("Modificar"))
                    {
                        int contraseniaId = Convert.ToInt32(dgvDetalleContrasenia.Rows[e.RowIndex].Cells["ContraseniaId"].Value.ToString());
                        
                        Contrasenia contrasenia = Sesion.BuscarContrasenia(contraseniaId);
                        IngresoPassword frmIngresoPassword = new IngresoPassword(contrasenia);
                        CargarTablaContrasenias(HistorialSeleccionado);
                    }
                    else
                    {
                        Alerta("La clave ya fue cambiada con anterioridad.", AlertaToast.enmTipo.Advertencia);
                    }
                }
            }
        }
        private string FormatoANumeroDeTarjeta(string numeroTarjeta)
        {
            string conFormato = "";
            int contador = 1;

            foreach (char caracter in numeroTarjeta)
            {
                if (contador > 12)
                {
                    conFormato += caracter;
                }
                else
                {
                    if (contador % 4 == 0)
                    {
                        conFormato += caracter + "-";
                    }
                    else
                    {
                        conFormato += caracter;
                    }
                }
                contador++;
            }

            return conFormato;
        }
    }
}
