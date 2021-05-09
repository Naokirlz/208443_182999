using Microsoft.VisualBasic;
using Negocio;
using Negocio.Contrasenias;
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

namespace Interfaz.Vulnerabilidades
{
    public partial class ResumenVulnerabilidades : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        private List<Contrasenia> contraseniasVulnerables;
        private List<TarjetaCredito> tarjetasVulnerables;

        public ResumenVulnerabilidades()
        {
            InitializeComponent();

            this.contraseniasVulnerables = new List<Contrasenia>();
            this.tarjetasVulnerables = new List<TarjetaCredito>();

            if(Sesion.MisFuentes.Count() == 0)
            {
                this.chkFuenteLocal.Visible = false;
            }
            else
            {
                this.chkFuenteLocal.Checked = true;
            }

            //DataGridViewButtonColumn columnaBotonVerTarjeta = new DataGridViewButtonColumn();
            //columnaBotonVerTarjeta.Name = "columnaVer";
            //columnaBotonVerTarjeta.Text = "Ver";
            //this.dgvVulnerabilidadesTarjetas.Columns.Add(columnaBotonVerTarjeta);
            //columnaBotonVerTarjeta.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn columnaBotonModificarContrasenia = new DataGridViewButtonColumn();
            columnaBotonModificarContrasenia.Name = "columnaModificar";
            columnaBotonModificarContrasenia.Text = "Modificar";
            this.dgvVulnerabilidadesContrasenias.Columns.Add(columnaBotonModificarContrasenia);
            columnaBotonModificarContrasenia.UseColumnTextForButtonValue = true;

            CargarTablaContraseniasVulnerables(Sesion.MisFuentes);
            CargarTablaTarjetasVulnerables(Sesion.MisFuentes);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            List<IFuente> fuentesAVerificar = new List<IFuente>();
            if (chkFuenteLocal.Checked)
            {
                fuentesAVerificar.Add(Sesion.MisFuentes[0]);
            }

            CargarTablaContraseniasVulnerables(fuentesAVerificar);
            CargarTablaTarjetasVulnerables(fuentesAVerificar);
        }

        private void CargarTablaContraseniasVulnerables(List<IFuente> fuentes)
        {
            List<Contrasenia> contraseniaVulnerableTemporal = new List<Contrasenia>();
            this.dgvVulnerabilidadesContrasenias.Rows.Clear();
            this.contraseniasVulnerables.Clear();
            foreach (IFuente fuente in fuentes)
            {
                contraseniaVulnerableTemporal = Sesion.ContraseniasVulnerables(fuente);
                foreach (Contrasenia contrasenia in contraseniaVulnerableTemporal)
                {
                    if (!this.contraseniasVulnerables.Contains(contrasenia))
                    {
                        contraseniasVulnerables.Add(contrasenia);
                        string password = Sesion.MostrarPassword(contrasenia.Password.Clave);

                        string[] fila = {
                            contrasenia.Categoria.Nombre,
                            contrasenia.Sitio,
                            contrasenia.Usuario,
                            new String('\u25CF', password.Length),
                            "Encontrada vulnerable " + Convert.ToString( contrasenia.CantidadVecesEncontradaVulnerable) + " veces."
                        };
                        this.dgvVulnerabilidadesContrasenias.Rows.Add(fila);
                    }
                }
            }
        }

        private void CargarTablaTarjetasVulnerables(List<IFuente> fuentes)
        {
            List<TarjetaCredito> tarjetasVulnerableTemporal = new List<TarjetaCredito>();
            this.dgvVulnerabilidadesTarjetas.Rows.Clear();
            this.tarjetasVulnerables.Clear();
            foreach (IFuente fuente in fuentes)
            {
                tarjetasVulnerableTemporal = Sesion.TarjetasCreditoVulnerables(fuente);
                foreach (TarjetaCredito tarjeta in tarjetasVulnerableTemporal)
                {
                    if (!this.tarjetasVulnerables.Contains(tarjeta))
                    {
                        tarjetasVulnerables.Add(tarjeta);
                        string[] fila = {
                            tarjeta.Categoria.Nombre,
                            tarjeta.Nombre,
                            tarjeta.Tipo,
                            tarjeta.Numero.ToString(),
                            "Encontrada vulnerable " + Convert.ToString( tarjeta.CantidadVecesEncontradaVulnerable) + " veces."
                        };
                        this.dgvVulnerabilidadesTarjetas.Rows.Add(fila);
                    }
                }
            }
        }

        private void dgvVulnerabilidadesContrasenias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                
                Contrasenia aModificar = this.contraseniasVulnerables[e.RowIndex];

                string nuevoPassword = Interaction.InputBox("Cual es la nueva contraseña?", "Modificar Contraseña", Sesion.MostrarPassword(aModificar.Password.Clave));
                //string password = (string)dgvContraseniasPorGrupo.Rows[e.RowIndex].Cells[4].Value;
                if (nuevoPassword == "") return;


                Contrasenia modificada = new Contrasenia()
                {
                    Sitio = aModificar.Sitio,
                    Categoria = aModificar.Categoria,
                    Id = aModificar.Id,
                    Notas = aModificar.Notas,
                    Usuario = aModificar.Usuario
                };
                modificada.Password.Clave = nuevoPassword;
                try
                {
                    Sesion.GestorContrasenia.ModificarContrasenia(modificada);
                    List<IFuente> fuentesAVerificar = new List<IFuente>();
                    if (chkFuenteLocal.Checked)
                    {
                        fuentesAVerificar.Add(Sesion.MisFuentes[0]);
                    }
                    CargarTablaContraseniasVulnerables(fuentesAVerificar);
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }

            }
        }
    }
}
