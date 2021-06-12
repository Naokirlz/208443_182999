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
    public partial class HistorialVulnerabilidades : UserControl
    {
        public HistorialVulnerabilidades()
        {
            InitializeComponent();
            this.dgvDetalle.Visible = false;
            CargarTablaHistorial();
        }

        private void CargarTablaHistorial()
        {
            //throw new NotImplementedException();.

            //id
            //sitio
            //usuario
            //clave filtrada
            //modificado o no
            //boton modificar
        }
    }
}
