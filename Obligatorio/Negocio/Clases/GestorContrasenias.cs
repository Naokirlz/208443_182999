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
            if (unaContrasena.FechaUltimaModificacion != null) ValidarFecha(unaContrasena.FechaUltimaModificacion);
            if (unaContrasena.Notas != null) ValidarLargoTexto(unaContrasena.Notas, 250, 0);
            if (unaContrasena.Password != null) ValidarLargoTexto(unaContrasena.Password, 25, 5);
            if (unaContrasena.Usuario != null) ValidarLargoTexto(unaContrasena.Usuario, 25, 5);
            if (unaContrasena.Sitio != null) ValidarLargoTexto(unaContrasena.Sitio, 25, 3);
            if (unaContrasena.Sitio == null || 
                unaContrasena.Usuario == null ||
                unaContrasena.Password == null ||
                unaContrasena.Categoria == null)
                throw new ExcepcionFaltaAtributo();
            unaContrasena.FechaUltimaModificacion = DateTime.Now;
            Contrasenia nuevaContrasenia = new Contrasenia()
            {
                Id = unaContrasena.Id,
                Sitio = unaContrasena.Sitio,
                Notas = unaContrasena.Notas,
                Password = unaContrasena.Password,
                Usuario = unaContrasena.Usuario,
                Categoria = unaContrasena.Categoria,
                FechaUltimaModificacion = unaContrasena.FechaUltimaModificacion
            };
            return Repositorio.Alta(nuevaContrasenia);
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
