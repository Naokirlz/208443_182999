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

namespace Interfaz.Vulnerabilidades
{
    public partial class ResumenVulnerabilidades : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        private List<Contrasenia> contraseniasVulnerables;

        public ResumenVulnerabilidades()
        {
            InitializeComponent();

            this.contraseniasVulnerables = new List<Contrasenia>();

            DataGridViewButtonColumn columnaBotonVerTarjeta = new DataGridViewButtonColumn();
            columnaBotonVerTarjeta.Name = "columnaVer";
            columnaBotonVerTarjeta.Text = "Ver";
            this.dgvVulnerabilidadesTarjetas.Columns.Add(columnaBotonVerTarjeta);
            columnaBotonVerTarjeta.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn columnaBotonVerContrasenia = new DataGridViewButtonColumn();
            columnaBotonVerContrasenia.Name = "columnaVer";
            columnaBotonVerContrasenia.Text = "Ver";
            this.dgvVulnerabilidadesContrasenias.Columns.Add(columnaBotonVerContrasenia);
            columnaBotonVerContrasenia.UseColumnTextForButtonValue = true;

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            List<IFuente> fuentesAVerificar = new List<IFuente>();
            if (chkFuenteLocal.Checked)
            {
                fuentesAVerificar.Add(Sesion.MisFuentes[0]);
            }

            List<Contrasenia> contraseniaVulnerableTemporal = new List<Contrasenia>();
            this.dgvVulnerabilidadesContrasenias.Rows.Clear();
            foreach(IFuente fuente in fuentesAVerificar)
            {
                contraseniaVulnerableTemporal = Sesion.ContraseniasVulnerables(fuente);
                foreach(Contrasenia contrasenia in contraseniaVulnerableTemporal)
                {
                    if (!this.contraseniasVulnerables.Contains(contrasenia))
                    {
                        contraseniasVulnerables.Add(contrasenia);
                        string[] fila = {
                            contrasenia.Categoria.Nombre,
                            contrasenia.Sitio,
                            contrasenia.Usuario,
                            contrasenia.Password,
                            "Encontrada vulnerable " + Convert.ToString( contrasenia.CantidadVecesEncontradaVulnerable) + " veces."
                        };
                        this.dgvVulnerabilidadesContrasenias.Rows.Add(fila);
                    }
                }
            }
            //CargarTablaContraseniasVulnerables();
        }

        private void CargarTablaContraseniasVulnerables()
        {
            List<Contrasenia> contraseniaVulnerableTemporal = new List<Contrasenia>();
            this.dgvVulnerabilidadesContrasenias.Rows.Clear();
            foreach (IFuente fuente in Sesion.MisFuentes)
            {
                contraseniaVulnerableTemporal = Sesion.ContraseniasVulnerables(fuente);
                foreach (Contrasenia contrasenia in contraseniaVulnerableTemporal)
                {
                    if (!this.contraseniasVulnerables.Contains(contrasenia))
                    {
                        contraseniasVulnerables.Add(contrasenia);
                        string[] fila = {
                            contrasenia.Categoria.Nombre,
                            contrasenia.Sitio,
                            contrasenia.Usuario,
                            contrasenia.Password,
                            "Encontrada vulnerable " + Convert.ToString( contrasenia.CantidadVecesEncontradaVulnerable) + " veces."
                        };
                        this.dgvVulnerabilidadesContrasenias.Rows.Add(fila);
                    }
                }
            }
        }
    }
}
