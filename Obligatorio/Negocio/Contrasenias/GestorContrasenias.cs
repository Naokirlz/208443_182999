using Negocio.Excepciones;
using System.Collections.Generic;
using System.Linq;


namespace Negocio.Contrasenias
{
    public class GestorContrasenias
    {
        public RepositorioContrasenias Repositorio;
                
        public GestorContrasenias() 
        {
            this.Repositorio = new RepositorioContrasenias();
        }
        
        public int Alta(Contrasenia unaContrasena)
        {
            ValidarCampos(unaContrasena);
            return Repositorio.Alta(unaContrasena);
        }

        public void Baja(int id)
        {
            Repositorio.Baja(id);
        }
        
        public void ModificarContrasenia(Contrasenia modificada)
        {
            ValidarCampos(modificada);
            Repositorio.ModificarContrasenia(modificada);
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
        
        public List<Contrasenia> ObtenerContraseniasVulnerables(IFuente fuente)
        {
            List<Contrasenia> contraseniasVulnerables = new List<Contrasenia>();
            IEnumerable<Contrasenia> todasLasContrasenias = this.ObtenerTodas();
            int cantidad = todasLasContrasenias.Count();

            for (int i = 0; i < cantidad; i++)
            {
                AgregarContraseniaSiEsVulnerable(contraseniasVulnerables, todasLasContrasenias.ElementAt(i), fuente);
            }

            return contraseniasVulnerables;
        }
        private void AgregarContraseniaSiEsVulnerable(List<Contrasenia> contrasenias, Contrasenia contrasenia, IFuente fuente)
        {
            int cantidadVecesEnFuente = BuscarContraseniaEnFuente(contrasenia, fuente);
            if (cantidadVecesEnFuente > 0)
            {
                contrasenia.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                this.ModificarContrasenia(contrasenia);
                contrasenias.Add(contrasenia);
            }

        }

        private int BuscarContraseniaEnFuente(Contrasenia item, IFuente fuente)
        {
            string password = this.MostrarPassword(item);
            return fuente.BuscarPasswordOContraseniaEnFuente(password);

        }

        private void ValidarCampos(Contrasenia aValidarContrasenia)
        {
            if (aValidarContrasenia.Sitio == null ||
                aValidarContrasenia.Usuario == null ||
                aValidarContrasenia.Password == null ||
                aValidarContrasenia.Categoria == null)
                throw new ExcepcionFaltaAtributo("Debe completar los campos obligatorios.");

            Validaciones.ValidarFecha(aValidarContrasenia.FechaUltimaModificacion);
            Validaciones.ValidarLargoTexto(aValidarContrasenia.Sitio, 25, 3, "sitio");
            Validaciones.ValidarLargoTexto(aValidarContrasenia.Usuario, 25, 5, "usuario");
            Validaciones.ValidarLargoTexto(aValidarContrasenia.Password.Clave, 25, 5, "contraseña");
            Validaciones.ValidarLargoTexto(aValidarContrasenia.Notas, 250, 0, "notas");
        }
    }
}
