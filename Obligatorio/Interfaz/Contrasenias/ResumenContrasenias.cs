using Negocio.Contrasenias;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negocio;
using System.Linq;

namespace Interfaz.Contrasenias
{
    public partial class ResumenContrasenias : UserControl
    {
        private Sesion Sesion = Sesion.ObtenerInstancia();
        private IEnumerable<Contrasenia> Contrasenias;
        private MostrarPassword FormModificar;

        public ResumenContrasenias()
        {
            InitializeComponent();

            FormModificar = null;

            CargarColumnasBotones();

            CargarTabla();
            
        }

        private void CargarColumnasBotones()
        {
            DataGridViewButtonColumn columnaBotonVer = new DataGridViewButtonColumn();
            columnaBotonVer.Name = "columnaBotonVer";
            columnaBotonVer.Text = "Ver";
            columnaBotonVer.HeaderText = "Ver";
            int columnRevelarIndex = 5;
            if (dgvContrasenias.Columns["columnaBotonVer"] == null)
            {
                this.dgvContrasenias.Columns.Insert(columnRevelarIndex, columnaBotonVer);
                columnaBotonVer.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonModificar = new DataGridViewButtonColumn();
            columnaBotonModificar.Name = "columnaBotonModificar";
            columnaBotonModificar.Text = "Modificar";
            columnaBotonModificar.HeaderText = "Modificar";
            columnRevelarIndex = 6;
            if (dgvContrasenias.Columns["columnaBotonModificar"] == null)
            {
                this.dgvContrasenias.Columns.Insert(columnRevelarIndex, columnaBotonModificar);
                columnaBotonModificar.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonEliminar = new DataGridViewButtonColumn();
            columnaBotonEliminar.Name = "columnaBotonEliminar";
            columnaBotonEliminar.Text = "Eliminar";
            columnaBotonEliminar.HeaderText = "Eliminar";
            columnRevelarIndex = 7;
            if (dgvContrasenias.Columns["columnaBotonEliminar"] == null)
            {
                this.dgvContrasenias.Columns.Insert(columnRevelarIndex, columnaBotonEliminar);
                columnaBotonEliminar.UseColumnTextForButtonValue = true;
            }
        }

        private void CargarTabla()
        {
            dgvContrasenias.Rows.Clear();
            Contrasenias = Sesion.ObtenerTodasLasContrasenias();
            foreach (Contrasenia contrasenia in Contrasenias)
            {
                string[] fila = {
                    contrasenia.Id.ToString(),
                    contrasenia.Categoria.Nombre,
                    contrasenia.Sitio,
                    contrasenia.Usuario,
                    contrasenia.FechaUltimaModificacion.ToShortDateString(),
                };
                this.dgvContrasenias.Rows.Add(fila);
            }
        }

        private void dgvContrasenias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int id = Int32.Parse(dgvContrasenias.Rows[e.RowIndex].Cells[0].Value.ToString());
                Contrasenia contraseniaSeleccionada = Contrasenias.ToList().Find(c => c.Id == id);

                if (e.ColumnIndex == 5)
                {
                    FormModificar = new MostrarPassword(contraseniaSeleccionada);
                }
                else if (e.ColumnIndex == 6)
                {
                    ModificarPasswordVentana frmModificar = new ModificarPasswordVentana(contraseniaSeleccionada);
                    CargarTabla();
                }
                else if (e.ColumnIndex == 7)
                {
                    VentanaConfirmar frmConfirmar = new VentanaConfirmar(contraseniaSeleccionada.Id, Sesion.BajaContrasenia)
                    {
                        MsgConfirmación = "Contraseña Eliminada con éxito!!",
                        MsgPregunta = "Realmente desea eliminar la contraseña??"
                    };
                    frmConfirmar.CargarFormulario();
                    CargarTabla();
                }
            }
        }

        private void ResumenContrasenias_Click(object sender, EventArgs e)
        {
            if (FormModificar != null) FormModificar = null;
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
