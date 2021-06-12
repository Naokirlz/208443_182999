using Negocio;
using Negocio.Contrasenias;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Vulnerabilidades
{
    public partial class HistorialVulnerabilidades : UserControl
    {
        Sesion Sesion = Sesion.ObtenerInstancia();
        public HistorialVulnerabilidades()
        {
            InitializeComponent();
            this.dgvDetalleContrasenia.Visible = false;
            this.dgvDetalleTarjeta.Visible = false;
            CargarTablaHistorial();
        }

        private void CargarTablaHistorial()
        {
            IEnumerable<Historial> historiales = Sesion.DevolverHistoriales();
            this.dgvHistorial.Rows.Clear();
            foreach (Historial historial in historiales)
            {
                string[] fila = {
                    historial.Fecha.ToString()
                };
                this.dgvHistorial.Rows.Add(fila);
            }
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1)
                {
                    this.dgvDetalleTarjeta.Visible = true;
                    this.dgvDetalleContrasenia.Visible = true;
                    DateTime historial = Convert.ToDateTime(dgvHistorial.Rows[e.RowIndex].Cells[0].Value.ToString());
                    CargarTablaContrasenias(historial);
                    //CargarTablaTarjetas(historial);
                }
            }
        }

        private void CargarTablaContrasenias(DateTime historial)
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
                this.dgvHistorial.Rows.Add(fila);
            }
        }
    }
}
