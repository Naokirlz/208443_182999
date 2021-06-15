using Interfaz.Alertas;
using Negocio;
using Negocio.Contrasenias;
using Negocio.InterfacesGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class ReporteFortalezaContrasenias : UserControl
    {
        private IContrasenia Sesion = new ContraseniaGUI();
        private List<Grupo> Grupos;
        private int GrupoMostrando;

        public ReporteFortalezaContrasenias()
        {
            InitializeComponent();
            dgvContraseniasPorGrupo.Visible = false;
            this.btnVolver.Visible = false;

            GenerarColumnaDeBotones();

            this.Grupos = Sesion.GenerarGrupos().ToList();
            CargarTabla();
        }

        private void GenerarColumnaDeBotones()
        {
            DataGridViewButtonColumn columnaBotonVer = new DataGridViewButtonColumn();
            columnaBotonVer.Name = "Ver";
            columnaBotonVer.Text = "Ver";
            int columnIndex = 2;
            if (dgvContrasenias.Columns["Ver"] == null)
            {
                this.dgvContrasenias.Columns.Insert(columnIndex, columnaBotonVer);
                columnaBotonVer.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonRevelar = new DataGridViewButtonColumn();
            columnaBotonRevelar.Name = "Revelar";
            columnaBotonRevelar.Text = "Revelar";
            columnaBotonRevelar.HeaderText = "Revelar";
            int columnRevelarIndex = 5;
            if (dgvContraseniasPorGrupo.Columns["Revelar"] == null)
            {
                this.dgvContraseniasPorGrupo.Columns.Insert(columnRevelarIndex, columnaBotonRevelar);
            }

            DataGridViewButtonColumn columnaBotonModificar = new DataGridViewButtonColumn();
            columnaBotonModificar.Name = "Modficar";
            columnaBotonModificar.Text = "Modficar";
            int columnGuardarIndex = 6;
            if (dgvContraseniasPorGrupo.Columns["Modficar"] == null)
            {
                this.dgvContraseniasPorGrupo.Columns.Insert(columnGuardarIndex, columnaBotonModificar);
                columnaBotonModificar.UseColumnTextForButtonValue = true;
            }
        }

        private void CargarTabla()
        {
            this.dgvContrasenias.Rows.Clear();
            foreach (Grupo grupo in Grupos)
            {
                string[] fila = {
                    grupo.Tipo,
                    grupo.Cantidad.ToString(),
                };
                this.dgvContrasenias.Rows.Add(fila);
            }
        }

        
        private void dgvContrasenias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 2 && e.RowIndex < 5)
                {
                    this.dgvContrasenias.Visible = false;
                    this.dgvContraseniasPorGrupo.Visible = true;
                    this.btnVolver.Visible = true;
                    this.GrupoMostrando = e.RowIndex;
                    CargarTablaPorGrupo(Grupos[e.RowIndex]);
                }
            }
        }

        private void CargarTablaPorGrupo(Grupo grupo)
        {
            this.dgvContraseniasPorGrupo.Rows.Clear();
            foreach (Contrasenia contrasenia in grupo.Contrasenias)
            {
                string password = new String('\u25CF', Sesion.MostrarPassword(contrasenia).Length);
                string[] fila = {
                    contrasenia.ContraseniaId.ToString(),
                    contrasenia.Categoria.Nombre,
                    contrasenia.Sitio,
                    contrasenia.Usuario,
                    password
                };
                this.dgvContraseniasPorGrupo.Rows.Add(fila);
            }
        }

        private void dgvContraseniasPorGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Grupo grupoMostrando = Grupos[this.GrupoMostrando];
                int id = Int32.Parse(dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[0].Value.ToString());
                Contrasenia contraseniaSeleccionada = grupoMostrando.Contrasenias.Find(c => c.ContraseniaId == id);

                if (e.ColumnIndex == 5)
                {
                    MostrarTextoCorrespondiente(e, contraseniaSeleccionada);
                }
                else if (e.ColumnIndex == 6)
                {
                    ModificarPassword(contraseniaSeleccionada);
                }
            }
        }

        private void MostrarTextoCorrespondiente(DataGridViewCellEventArgs e, Contrasenia contraseniaSeleccionada)
        {
            string password = contraseniaSeleccionada.Password.Clave;
            if (dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Revelar"].Value.ToString() == "Revelar")
            {
                dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[4].Value = password;
                dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Revelar"].Value = "Ocultar";
            }
            else
            {
                password = new String('\u25CF', password.Length);
                dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[4].Value = password;
                dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Revelar"].Value = "Revelar";
            }
        }

        private void ModificarPassword(Contrasenia contraseniaSeleccionada)
        {
            IngresoPassword frmIngresoPassword = new IngresoPassword(contraseniaSeleccionada);
            Sesion.GenerarGrupos();
            Grupo grupoActualizado = Grupos[this.GrupoMostrando];
            CargarTablaPorGrupo(grupoActualizado);
            CargarTabla();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.dgvContrasenias.Visible = true;
            this.dgvContraseniasPorGrupo.Visible = false;
            this.btnVolver.Visible = false;
        }

        private void dgvContraseniasPorGrupo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == this.dgvContraseniasPorGrupo.NewRowIndex)
                return;

            if (e.ColumnIndex == this.dgvContraseniasPorGrupo.Columns["Revelar"].Index)
            {
                string charOculto = new String('\u25CF', 1);
                string valor = dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Password"].Value.ToString();

                if (valor.Contains(charOculto))
                    dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Revelar"].Value = "Revelar";
                else
                {
                    dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Revelar"].Value = "Ocultar";
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