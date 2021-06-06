using Negocio.Persistencia;
using Negocio.Utilidades;
using System.Collections.Generic;
using System.Linq;


namespace Negocio.Contrasenias
{
    public class GestorContrasenias
    {
        private RepositorioContraseniasMemoria repositorio;
                
        public GestorContrasenias() 
        {
            this.repositorio = new RepositorioContraseniasMemoria();
        }
        
        public int Alta(Contrasenia unaContrasena)
        {
            ValidarCampos(unaContrasena);
            return repositorio.Alta(unaContrasena);
        }

        public void Baja(int id)
        {
            Contrasenia eliminar = new Contrasenia()
            {
                Id = id
            };
            repositorio.Baja(eliminar);
        }
        
        public void ModificarContrasenia(Contrasenia modificada)
        {
            ValidarCampos(modificada);
            repositorio.Modificar(modificada);
        }
      
        public Contrasenia Buscar(int id)
        {
            Contrasenia buscar = new Contrasenia()
            {
                Id = id
            };
            return repositorio.Buscar(buscar);
        }
        
        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            return repositorio.ObtenerTodas();
        }

        public string MostrarPassword(Contrasenia password)
        {
            return password.Password.Clave;
        }
        
        public IEnumerable<Contrasenia> ObtenerContraseniasVulnerables(IFuente fuente)
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

        private int BuscarContraseniaEnFuente(Contrasenia contrasenia, IFuente fuente)
        {
            string password = this.MostrarPassword(contrasenia);
            return fuente.BuscarPasswordOContraseniaEnFuente(password);

        }

        private void ValidarCampos(Contrasenia contrasenia)
        {
            if (contrasenia.Sitio == null ||
                contrasenia.Usuario == null ||
                contrasenia.Password == null ||
                contrasenia.Categoria == null)
                throw new ExcepcionFaltaAtributo("Debe completar los campos obligatorios.");

            Validaciones.ValidarFecha(contrasenia.FechaUltimaModificacion);
            Validaciones.ValidarLargoTexto(contrasenia.Sitio, 25, 3, "sitio");
            Validaciones.ValidarLargoTexto(contrasenia.Usuario, 25, 5, "usuario");
            Validaciones.ValidarPassword(contrasenia.Password.Clave, 25, 5);
            if (contrasenia.Notas != null) Validaciones.ValidarLargoTexto(contrasenia.Notas, 250, 0, "notas");
        }
    }
}
