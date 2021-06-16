using Negocio.Excepciones;
using Negocio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string ClaveMaestra { get; set; }
        private IRepositorio<Usuario> repositorio;
        public Usuario()
        {
            this.ClaveMaestra = "";
            FabricaRepositorio fabrica = new FabricaRepositorio();
            this.repositorio = fabrica.CrearRepositorioUsuario();
        }

        public bool Login(string password)
        {
            if (!VerificarUsuarioExiste()) throw new ExcepcionAccesoDenegado("El usuario no existe.");
            Usuario buscado = repositorio.Buscar(this);
            if (buscado.ClaveMaestra != password)
                throw new ExcepcionAccesoDenegado("El usuario o contraseña no son coinciden.");
            return true;
        }

        public void GuardarPrimerPassword(string primerPassword)
        {
            Validaciones.ValidarPassword(primerPassword, 25, 5);
            this.ClaveMaestra = primerPassword;
            repositorio.Alta(this);
        }

        public void CambiarPassword(string nuevoPassword)
        {
            Validaciones.ValidarLargoTexto(nuevoPassword, 25, 5, "nuevo password");
            this.ClaveMaestra = nuevoPassword;
            repositorio.Modificar(this);
        }

        internal bool VerificarUsuarioExiste()
        {
            Usuario buscado = repositorio.Buscar(this);
            if (buscado != null)
            {
                return true;
            }
            return false;
        }

        internal void LimpiarBD()
        {
            repositorio.TestClear();
        }
    }
}
