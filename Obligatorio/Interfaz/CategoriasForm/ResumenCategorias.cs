using System.Collections.Generic;
using System.Windows.Forms;
using Negocio;
using Negocio.Categorias;

namespace Interfaz.CategoriasForm
{
    public partial class ResumenCategorias : UserControl
    {
        public ResumenCategorias()
        {
            Sesion Sesion = Sesion.Singleton;
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
