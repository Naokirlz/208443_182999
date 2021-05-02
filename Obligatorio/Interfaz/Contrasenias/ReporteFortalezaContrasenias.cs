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
            columnaBotonVer.Name = "columnaVer";
            columnaBotonVer.Text = "Ver";
            int columnIndex = 2;
            if (dgvContrasenias.Columns["columnaVer"] == null)
            {
                this.dgvContrasenias.Columns.Insert(columnIndex, columnaBotonVer);
                columnaBotonVer.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonRevelar = new DataGridViewButtonColumn();
            columnaBotonRevelar.Name = "columnaRevelar";
            columnaBotonRevelar.Text = "Revelar";
            int columnRevelarIndex = 5;
            if (dgvContraseniasPorGrupo.Columns["columnaRevelar"] == null)
            {
                this.dgvContraseniasPorGrupo.Columns.Insert(columnRevelarIndex, columnaBotonRevelar);
                columnaBotonRevelar.UseColumnTextForButtonValue = true;
            }

            DataGridViewButtonColumn columnaBotonGuardar = new DataGridViewButtonColumn();
            columnaBotonGuardar.Name = "columnaGuardar";
            columnaBotonGuardar.Text = "Guardar";
            int columnGuardarIndex = 6;
            if (dgvContraseniasPorGrupo.Columns["columnaGuardar"] == null)
            {
                this.dgvContraseniasPorGrupo.Columns.Insert(columnGuardarIndex, columnaBotonGuardar);
                columnaBotonGuardar.UseColumnTextForButtonValue = true;
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
                List<Contrasenia> contrasenias = Sesion.GestorContrasenia.ListarContrasenias();
                foreach (Contrasenia contrasenia in contrasenias)
                {
                    string password = Sesion.GestorContrasenia.MostrarPassword(contrasenia.Password);
                    if (Sesion.GestorContrasenia.VerificarFortaleza(contrasenia) == grupo.ToUpper())
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
            if (e.ColumnIndex == 2 && e.RowIndex < 5)
            {
                this.dgvContrasenias.Visible = false;
                this.dgvContraseniasPorGrupo.Visible = true;
                this.btnVolver.Visible = true;
                this.GrupoMostrando = e.RowIndex;
                CargarTablaPorGrupo(Grupos[e.RowIndex]);
                MessageBox.Show(Grupos[e.RowIndex].Tipo);
            }
        }

        private void CargarTablaPorGrupo(Grupo grupo)
        {
            this.dgvContraseniasPorGrupo.Rows.Clear();
            foreach (Contrasenia contrasenia in grupo.Contrasenias)
            {
                string password = "";
                foreach(char c in Sesion.GestorContrasenia.MostrarPassword(contrasenia.Password))
                {
                    password += "*";
                }
                string[] fila = {
                    contrasenia.Categoria.Nombre,
                    contrasenia.Sitio,
                    contrasenia.Usuario,
                    contrasenia.FechaUltimaModificacion.ToShortDateString(),
                    password
                };
                this.dgvContraseniasPorGrupo.Rows.Add(fila);
            }
        }

        private void dgvContraseniasPorGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Grupo grupoMostrando = Grupos[this.GrupoMostrando];

            if (e.ColumnIndex == 5)
            {
                string password = grupoMostrando.Contrasenias[e.RowIndex].Password;
                password = Sesion.GestorContrasenia.MostrarPassword(password);
                dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[4].Value = password;
            }else if(e.ColumnIndex == 6)
            {
                string password = (string)dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[4].Value;
                Contrasenia modificada = grupoMostrando.Contrasenias[e.RowIndex];
                modificada.Password = password;
                try
                {
                    Sesion.GestorContrasenia.ModificarContrasenia(modificada);
                    GenerarGrupos();
                    CargarTablaPorGrupo(grupoMostrando);
                    CargarTabla();
                }
                catch(Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.dgvContrasenias.Visible = true;
            this.dgvContraseniasPorGrupo.Visible = false;
            this.btnVolver.Visible = false;
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