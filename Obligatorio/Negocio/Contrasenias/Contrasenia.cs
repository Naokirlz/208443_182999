using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Negocio.Categorias;
using static Negocio.Contrasenias.Password;

namespace Negocio.Contrasenias
{
    [Table("Contrasenia")]
    public class Contrasenia: IComparable<Contrasenia>
    {
       
        public int ContraseniaId { get; set; }
        public virtual Password Password { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Sitio { get; set; }
        
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Usuario { get; set; }
         
        [StringLength(250, MinimumLength = 0)]
        public string Notas {get; set; }
        
        public Categoria Categoria { get; set; }

        [Required]
        public DateTime  FechaUltimaModificacion { get; set; }
        
        public int CantidadVecesEncontradaVulnerable { get; set; }
         
        public int CompareTo(Contrasenia otraContrasenia)
        {
            return this.Categoria.Nombre.CompareTo(otraContrasenia.Categoria.Nombre);
        }

        public override string ToString()
        {
            return this.Sitio + " | " + this.Usuario;
        }

        public EnumColor FortalezaDelPassword()
        {
            return this.Password.ColorPassword;
        }

    }

    
}
