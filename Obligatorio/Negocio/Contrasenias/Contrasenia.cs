using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Categorias;


namespace Negocio.Contrasenias
{
     
    public class Contrasenia: IComparable<Contrasenia>
    {
        public int Id { get; set; }
        public string Sitio { get; set; }
        public string Usuario { get; set; }
        public Password Password { get; set; }
        public string Notas {get; set; }
        public Categoria Categoria { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public int CantidadVecesEncontradaVulnerable { get; set; }

        public Contrasenia()
        {
            
        }
         
        public int CompareTo(Contrasenia otraContrasenia)
        {
            return this.Categoria.Nombre.CompareTo(otraContrasenia.Categoria.Nombre);

        }

        public override string ToString()
        {
            return this.Sitio + " | " + this.Usuario;
        }
    }

    
}
