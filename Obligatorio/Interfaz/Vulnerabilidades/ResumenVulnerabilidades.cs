using Microsoft.VisualBasic;
using Negocio;
using Negocio.Contrasenias;
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

            if(Sesion.MisFuentes.Count() == 0) this.chkFuenteLocal.Visible = false;
                else this.chkFuenteLocal.Checked = true;

            DataGridViewButtonColumn columnaBotonModificarContrasenia = new DataGridViewButtonColumn();
            columnaBotonModificarContrasenia.Name = "Modificar";
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
            IEnumerable<Contrasenia> contraseniaVulnerableTemporal = new List<Contrasenia>();
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
                        string password = Sesion.MostrarPassword(contrasenia);

                        string[] fila = {
                            contrasenia.Id.ToString(),
                            contrasenia.Categoria.Nombre,
                            contrasenia.Sitio,
                            contrasenia.Usuario,
                            "Vulnerable " + Convert.ToString( contrasenia.CantidadVecesEncontradaVulnerable) + " veces."
                        };
                        this.dgvVulnerabilidadesContrasenias.Rows.Add(fila);
                    }
                }
            }
        }

        private void CargarTablaTarjetasVulnerables(List<IFuente> fuentes)
        {
            IEnumerable<TarjetaCredito> tarjetasVulnerableTemporal = new List<TarjetaCredito>();
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
                            tarjeta.Id.ToString(),
                            tarjeta.Categoria.Nombre,
                            tarjeta.Nombre,
                            tarjeta.Tipo,
                            FormatoANumeroDeTarjeta(tarjeta.Numero.ToString()),
                            "Vulnerable " + Convert.ToString( tarjeta.CantidadVecesEncontradaVulnerable) + " veces."
                        };
                        this.dgvVulnerabilidadesTarjetas.Rows.Add(fila);
                    }
                }
            }
        }

        private void dgvVulnerabilidadesContrasenias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 5)
                {
                    int id = Int32.Parse(dgvVulnerabilidadesContrasenias.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Contrasenia contraseniaSeleccionada = contraseniasVulnerables.ToList().Find(c => c.Id == id);

                    IngresoPassword frmIngresoPassword = new IngresoPassword(contraseniaSeleccionada);

                    List<IFuente> fuentesAVerificar = new List<IFuente>();
                    if (chkFuenteLocal.Checked)
                    {
                        fuentesAVerificar.Add(Sesion.MisFuentes[0]);
                    }
                    CargarTablaContraseniasVulnerables(fuentesAVerificar);
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
    }
}
