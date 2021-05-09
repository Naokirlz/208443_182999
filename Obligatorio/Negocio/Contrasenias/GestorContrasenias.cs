using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Negocio.Contrasenias
{
    public class GestorContrasenias
    {
        public RepositorioContrasenias Repositorio;
                
        public GestorContrasenias() {
            this.Repositorio = new RepositorioContrasenias();
        }
        
        public int Alta(Contrasenia unaContrasena)
        {
            ValidarCampos(unaContrasena);
            unaContrasena.FechaUltimaModificacion = DateTime.Now;
            return Repositorio.Alta(unaContrasena);
        }
        
        public void Baja(int id)
        {
            Repositorio.Baja(id);
        }
        
        public void ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            ValidarCampos(aModificarContrasenia);
            Repositorio.ModificarContrasenia(aModificarContrasenia);
            
        }
        
        public Contrasenia Buscar(int id)
        {
            return Repositorio.BuscarPorId(id);
        }
        
        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            return Repositorio.ObtenerTodas();
             
        }

        public string MostrarPassword(Contrasenia password)
        {
            return password.Password.Clave;
        }

        private void ValidarCampos(Contrasenia aValidarContrasenia)
        {
            if (aValidarContrasenia.Sitio == null ||
                aValidarContrasenia.Usuario == null ||
                aValidarContrasenia.Password == null ||
                aValidarContrasenia.Categoria == null)
                throw new ExcepcionFaltaAtributo("Debe completar los campos obligatorios.");

            ValidarFecha(aValidarContrasenia.FechaUltimaModificacion);
            ValidarLargoTexto(aValidarContrasenia.Sitio, 25, 3, "sitio");
            ValidarLargoTexto(aValidarContrasenia.Usuario, 25, 5, "usuario");
            ValidarLargoTexto(aValidarContrasenia.Password.Clave, 25, 5, "contraseña");
            ValidarLargoTexto(aValidarContrasenia.Notas, 250, 0, "notas");
        }


        private void ValidarLargoTexto(string texto, int largoMax, int largoMin, string campo)
        {
            texto = texto.Trim();
            if (texto.Length > largoMax || texto.Length < largoMin) throw new ExcepcionLargoTexto("El largo del campo " + campo
                + " debe ser de entre " + largoMin.ToString() + " y " + largoMax.ToString() + " caracteres.");
        }
        
        private void ValidarFecha(DateTime unaFecha)
        {
            if (unaFecha > DateTime.Now) throw new ExcepcionFechaIncorrecta("La fecha de modificación no puede ser futura.");
        }

        
    }
}
