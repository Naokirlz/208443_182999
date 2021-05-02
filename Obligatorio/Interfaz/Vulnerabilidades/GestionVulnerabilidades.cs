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
    public partial class GestionVulnerabilidades : UserControl
    {
        public GestionVulnerabilidades()
        {
            InitializeComponent();
        }

        private void btnResumenVulnerabilidades_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            UserControl resumenVulnerabilidades = new ResumenVulnerabilidades();
            pnlGestor.Controls.Add(resumenVulnerabilidades);
        }
    }
}
