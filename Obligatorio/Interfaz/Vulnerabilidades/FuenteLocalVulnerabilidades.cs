using Negocio;
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
    public partial class FuenteLocalVulnerabilidades : UserControl
    {
        Sesion Sesion = Sesion.Singleton;
        IFuente FuenteLocal;
        public FuenteLocalVulnerabilidades()
        {
            InitializeComponent();
            //acá debería buscar si alguna de las fuentes es la fuente local, y a esa le pongo el contenido
            //esto tiene que ser de sesión
            

            //acá agrego lo de fuente local, que siempre debería aparecer
            //si tengo más fuentes las agrego en la ventana de validación, con la lista de fuentes que tenga

            //esto sacarlo después
            bool encontre = false;
            foreach (IFuente fuente in Sesion.MisFuentes)
            {
                string tipoFuente = fuente.GetType().ToString();
                if (tipoFuente == "Negocio.FuenteLocal")
                {
                    this.FuenteLocal = fuente;
                    encontre = true;
                }
            }

            if (!encontre)
            {
                this.FuenteLocal = new FuenteLocal();
                this.Sesion.MisFuentes.Add(this.FuenteLocal);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string[] fuentes = this.txtEntradaFuenteLocal.Text.Split('\n');
            foreach(string fila in fuentes)
            {
                FuenteLocal.AgregarPasswordOContraseniaVulnerable(fila.TrimEnd('\r'));
            }
            this.txtEntradaFuenteLocal.Text = "";
        }
    }
}
