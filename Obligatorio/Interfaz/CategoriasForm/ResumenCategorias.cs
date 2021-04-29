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
using Negocio.Categorias;
using Negocio.Contrasenias;

namespace Interfaz.CategoriasForm
{
    public partial class ResumenCategorias : UserControl
    {
        public ResumenCategorias()
        {
            Sesion Sesion = Sesion.Singleton;
            InitializeComponent();
            List<Categoria> categorias = Sesion.GestorCategoria.ListarCategorias();
            foreach (Categoria categoria in categorias)
            {
                string[] fila = {
                    categoria.Nombre,
                };
                this.dgvTarjetas.Rows.Add(fila);
            }
        }
    }
}
