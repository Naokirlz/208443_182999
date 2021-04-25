using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class GestorContrasenias
    {
        public RepositorioContrasenias Repositorio;
        public GestorContrasenias() {
            this.Repositorio = new RepositorioContrasenias();
        }

        public Contrasenia Alta(Contrasenia unaContrasena)
        {
            if (unaContrasena.Sitio == null ||
                unaContrasena.Usuario == null ||
                unaContrasena.Password == null ||
                unaContrasena.Categoria == null)
                throw new ExcepcionFaltaAtributo();

            ValidarFecha(unaContrasena.FechaUltimaModificacion);
            ValidarLargoTexto(unaContrasena.Notas, 250, 0);
            ValidarLargoTexto(unaContrasena.Password, 25, 5);
            ValidarLargoTexto(unaContrasena.Usuario, 25, 5);
            ValidarLargoTexto(unaContrasena.Sitio, 25, 3);
            
            unaContrasena.FechaUltimaModificacion = DateTime.Now;
            return Repositorio.Alta(unaContrasena);
        }

        private void ValidarLargoTexto(string texto, int largoMax, int largoMin)
        {
            if (texto.Length > largoMax || texto.Length < largoMin) throw new ExcepcionLargoTexto();
        }

        public List<Contrasenia> ListarContrasenias()
        {
            return Repositorio.ListarContrasenias();
        }

        private void ValidarFecha(DateTime unaFecha)
        {
            if (unaFecha > DateTime.Now) throw new ExcepcionFechaIncorrecta();
        }

        public Contrasenia ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            ValidarLargoTexto(aModificarContrasenia.Sitio, 25, 3);
            return Repositorio.ModificarContrasenia(aModificarContrasenia);
        }

        public Contrasenia Buscar(int id)
        {
            return Repositorio.Buscar(id);
        }
    }
}
