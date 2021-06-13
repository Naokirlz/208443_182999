using System.Collections.Generic;


namespace Negocio.Contrasenias
{
    public class Grupo
    {
        public string Tipo { set; get; }
        public List<Contrasenia> Contrasenias { set; get; }
        public int Cantidad { set; get; }

        public Grupo()
        {
            this.Contrasenias = new List<Contrasenia>();
            Cantidad = 0;
        }
    }
}
