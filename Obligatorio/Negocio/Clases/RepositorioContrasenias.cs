using System.Collections.Generic;

namespace Negocio.Clases
{
    public class RepositorioContrasenias
    {
        private List<Contrasenia> Contrasenias { get; set; }

        public RepositorioContrasenias()
        {
            this.Contrasenias = new List<Contrasenia>();
        }

        public Contrasenia Alta(Contrasenia unaContrasenia)
        {
            this.Contrasenias.Add(unaContrasenia);
            return unaContrasenia;
        }

        public List<Contrasenia> ListarContrasenias()
        {
            return this.Contrasenias;
        }
    }
}