using System.Collections.Generic;
using System.Windows.Forms;
using Negocio.Categorias;
using Negocio.InterfacesGUI;

namespace Interfaz.Categorias
{
    public partial class ResumenCategorias : UserControl
    {
        public ICategoria Sesion = new CategoriaGUI();
        public ResumenCategorias()
        {
            InitializeComponent();
            IEnumerable<Categoria> categorias = Sesion.ObtenerTodasLasCategorias();
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
