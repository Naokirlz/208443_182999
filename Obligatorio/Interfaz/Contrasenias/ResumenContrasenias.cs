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
using Negocio;
using Microsoft.VisualBasic;
using Negocio.Excepciones;

namespace Interfaz.Contrasenias
{
    public partial class ResumenContrasenias : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        private IEnumerable<Contrasenia> Contrasenias;
        private MostrarPassword FormModificar;

        public ResumenContrasenias()
        {
            InitializeComponent();

            FormModificar = null;

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

            CargarTabla();
            
        }

        private void CargarTabla()
        {
            dgvContrasenias.Rows.Clear();
            Contrasenias = Sesion.ListarContrasenias();
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
                string id = dgvContrasenias.Rows[e.RowIndex].Cells[0].Value.ToString();
                Contrasenia contraseniaSeleccionada = null;
                foreach (Contrasenia contrasenia in Contrasenias)
                {
                    if (contrasenia.Id.ToString() == id) contraseniaSeleccionada = contrasenia;
                }
                if (e.ColumnIndex == 5)
                {
                    FormModificar = new MostrarPassword(contraseniaSeleccionada);
                }
                else if (e.ColumnIndex == 6)
                {
                    string nuevoPassword = Interaction.InputBox("Cual es la nueva contraseña?", "Modificar Contraseña", contraseniaSeleccionada.Password.Clave);

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
                        Sesion.ModificarContrasenia(modificada);
                        CargarTabla();
                        Alerta("Contraseña modificada con éxito!!", AlertaToast.enmTipo.Exito);
                    }
                    catch (ExcepcionLargoTexto excep)
                    {
                        Alerta(excep.Message, AlertaToast.enmTipo.Error);
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    try
                    {
                        DialogResult respuesta = MessageBox.Show("Realmente desea eliminar la contraseña?",
                            "Alerta",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.Yes)
                        {
                            this.Sesion.BajaContrasenia(contraseniaSeleccionada.Id);
                            CargarTabla();
                            Alerta("Contraseña eliminada con éxito!!", AlertaToast.enmTipo.Exito);
                        }

                    }
                    catch (ExcepcionElementoNoExiste unaExcepcion)
                    {
                        Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
                    }
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
