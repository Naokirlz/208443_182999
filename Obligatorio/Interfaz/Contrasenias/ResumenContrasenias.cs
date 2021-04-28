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

namespace Interfaz.Contrasenias
{
    public partial class ResumenContrasenias : UserControl
    {
        public ResumenContrasenias()
        {
            Sesion Sesion = Sesion.Singleton;
            InitializeComponent();
            List<Contrasenia> contrasenias = Sesion.GestorContrasenia.ListarContrasenias();
            foreach (Contrasenia contrasenia in contrasenias)
            {
                string[] fila = {
                    contrasenia.Categoria.Nombre,
                    contrasenia.Sitio,
                    contrasenia.Usuario,
                    contrasenia.FechaUltimaModificacion.ToShortDateString(),
                };
                this.dgvTarjetas.Rows.Add(fila);
            }
        }
    }
}
