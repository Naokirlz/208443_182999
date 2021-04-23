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

        public void Alta(Contrasenia unaContrasena)
        {
            if (unaContrasena.FechaUltimaModificacion != null) ValidarFecha(unaContrasena.FechaUltimaModificacion);
            if (unaContrasena.Notas != null) ValidarLargoTexto(unaContrasena.Notas, 250);
            if (unaContrasena.Password != null) ValidarLargoTexto(unaContrasena.Password, 25);
            Repositorio.Alta(unaContrasena);
        }

        private void ValidarLargoTexto(string texto, int largoMax)
        {
            if (texto.Length > largoMax) throw new ExcepcionLargoTexto();
        }

        public List<Contrasenia> ListarContrasenias()
        {
            return Repositorio.ListarContrasenias();
        }

        private void ValidarFecha(DateTime unaFecha)
        {
            if (unaFecha > DateTime.Now) throw new ExcepcionFechaIncorrecta();
        }
    }
}
