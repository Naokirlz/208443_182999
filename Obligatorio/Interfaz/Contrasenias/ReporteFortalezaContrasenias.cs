using Microsoft.VisualBasic;
using Negocio;
using Negocio.Contrasenias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class ReporteFortalezaContrasenias : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        private List<Grupo> Grupos;
        private int GrupoMostrando;

        public ReporteFortalezaContrasenias()
        {
            InitializeComponent();
            dgvContraseniasPorGrupo.Visible = false;
            this.btnVolver.Visible = false;

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


            this.Grupos = new List<Grupo>();
            GenerarGrupos();
            CargarTabla();
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

        private void GenerarGrupos()
        {
            this.Grupos.Clear();
            string[] grupos = { "Rojo", "Naranja", "Amarillo", "Verde Claro", "Verde Oscuro" };
            foreach(string grupo in grupos)
            {
                Grupo nuevo = new Grupo()
                {
                    Tipo = grupo
                };
                IEnumerable<Contrasenia> contrasenias = Sesion.ListarContrasenias();
                foreach (Contrasenia contrasenia in contrasenias)
                {
                    string password = Sesion.MostrarPassword(contrasenia);
                    if (contrasenia.Password.ColorPassword.ToString() == grupo.ToUpper())
                    {
                        nuevo.Cantidad = nuevo.Cantidad + 1;
                        nuevo.Contrasenias.Add(contrasenia);
                    }
                }
                this.Grupos.Add(nuevo);
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
                    contrasenia.Id.ToString(),
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
                string id = dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[0].Value.ToString();
                Contrasenia contraseniaSeleccionada = null;
                foreach (Contrasenia contrasenia in grupoMostrando.Contrasenias)
                {
                    if (contrasenia.Id.ToString() == id) contraseniaSeleccionada = contrasenia;
                }
                
                string password = contraseniaSeleccionada.Password.Clave;

                if (e.ColumnIndex == 5)
                {
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
                else if (e.ColumnIndex == 6)
                {
                    string nuevoPassword = Interaction.InputBox("Cual es la nueva contraseña?", "Modificar Contraseña", password);
                    //string password = (string)dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[4].Value;
                    if (nuevoPassword == "") return;

                    Contrasenia modificada = new Contrasenia()
                    {
                        Sitio = contraseniaSeleccionada.Sitio,
                        Categoria = contraseniaSeleccionada.Categoria,
                        Id = contraseniaSeleccionada.Id,
                        Notas = contraseniaSeleccionada.Notas,
                        Usuario = contraseniaSeleccionada.Usuario,
                        Password = contraseniaSeleccionada.Password
                    };
                    
                    try
                    {
                        modificada.Password.Clave = nuevoPassword;
                        Sesion.GestorContrasenia.ModificarContrasenia(modificada);
                        GenerarGrupos();
                        Grupo grupoActualizado = Grupos[this.GrupoMostrando];
                        CargarTablaPorGrupo(grupoActualizado);
                        CargarTabla();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.dgvContrasenias.Visible = true;
            this.dgvContraseniasPorGrupo.Visible = false;
            this.btnVolver.Visible = false;
        }

        private void dgvContraseniasPorGrupo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //// Si esta es una fila de encabezado o una fila nueva, no haga nada
            if (e.RowIndex < 0 || e.RowIndex == this.dgvContraseniasPorGrupo.NewRowIndex)
                return;

            // Si formatea su columna deseada, establezca el valor
            if (e.ColumnIndex == this.dgvContraseniasPorGrupo.Columns["Revelar"].Index)
            {
                //Puedes poner tu lógica dinámica aquí
                //y usa diferentes valores basados en otros valores de celda,
                //por ejemplo celda "clean"
                string charOculto = new String('\u25CF', 1);
                string valor = dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Password"].Value.ToString();


                if (valor.Contains(charOculto))
                    dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Revelar"].Value = "Revelar";
                else
                {
                    dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells["Revelar"].Value = "Ocultar";
                }


                //this.dataGridView1.Rows[e.RowIndex].Cells["clean"].Value
                //e.Value = "Lavado";
            }
        }
    }

    internal class Grupo
    {
        public string Tipo { set; get; }
        public List<Contrasenia> Contrasenias { set; get; }
        public int Cantidad { set; get; }

        public Grupo()
        {
            this.Contrasenias = new List<Contrasenia>();
            Cantidad = 0;
        }
    }
}