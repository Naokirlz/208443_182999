using Negocio.Persistencia;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace Negocio.Categorias
{
    public class GestorCategorias
    {
        private IRepositorio<Categoria> repositorio;

        public GestorCategorias()
        {
            //this.repositorio = new RepositorioCategoriasMemoria();
            this.repositorio = new RepositorioCategoriasEntity();

        }

        public int Alta(string nombre)
        {
            Validaciones.ValidarLargoTexto(nombre, 15, 3, "nombre");
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
            //Validaciones.ValidarLargoTexto(nombreNuevo, 15, 3, "nombre");
            Categoria Modificar = new Categoria("Modificar")
            {
                Id = id,
                Nombre = nombreNuevo
            };
            try { 
            repositorio.Modificar(Modificar);
            }
            catch (DbUpdateException ex)
            {
                throw new ExcepcionElementoNoExiste("Error: En la Base de Datos",ex);

            }
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
