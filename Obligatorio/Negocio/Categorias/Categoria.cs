
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio.Categorias
{
    [Table("Categoria")]
    public class Categoria
    {
       
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Largo entre 3 y 15")]
        public string Nombre { get; set; }

        public Categoria()
        {
            
        }
        public Categoria(string nombre)
        {
            this.Nombre = nombre;
        }
               
        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
