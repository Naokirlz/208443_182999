using Negocio.Persistencia;
using System.Collections.Generic;


namespace Negocio.Categorias
{
    public class GestorCategorias
    {
        private const int LARGO_MAXIMO_CATEGORIA = 15;
        private const int LARGO_MINIMO_CATEGORIA = 3;
        private IRepositorio<Categoria> repositorio;

        public GestorCategorias()
        {
            FabricaRepositorio fabrica = new FabricaRepositorio();
            this.repositorio = fabrica.CrearRepositorioCategorias();
        }

        public int Alta(string nombre)
        {
            Validaciones.ValidarLargoTexto(nombre, LARGO_MAXIMO_CATEGORIA, LARGO_MINIMO_CATEGORIA, "nombre");
            return repositorio.Alta(new Categoria(nombre));

        }

        public void LimpiarBD()
        {
            repositorio.TestClear();
        }

        public void Baja(int id)
        {
            Categoria borrar = new Categoria("Borrar")
            {
                Id = id
            };
            repositorio.Baja(borrar);
        }

        public void ModificarCategoria(int id, string nombreNuevo)
        {
            Validaciones.ValidarLargoTexto(nombreNuevo, LARGO_MAXIMO_CATEGORIA, LARGO_MINIMO_CATEGORIA, "nombre");
            Categoria Modificar = new Categoria("Modificar")
            {
                Id = id,
                Nombre = nombreNuevo
            };
            repositorio.Modificar(Modificar);
            
           
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            Categoria Buscar = new Categoria("Buscar");
            Buscar.Id = id;
            return repositorio.Buscar(Buscar);
        }

        public IEnumerable<Categoria> ObtenerTodas()
        {
            return repositorio.ObtenerTodas();
        }

    }
}
