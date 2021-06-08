using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Negocio.Categorias;

namespace Negocio.TarjetaCreditos
{

    [Table("TarjetaCredito")]
    public class TarjetaCredito: IComparable<TarjetaCredito>
    {
        public int Id { get; set; }
        public Categoria Categoria { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Largo entre 3 y 25")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Largo entre 3 y 25")]
        public string Tipo { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Largo 16")]
        public string Numero { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Largo 3")]
        public string Codigo { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Vencimiento { get; set; }

        [StringLength(250, MinimumLength = 0, ErrorMessage = "Largo menor a 250")]
        public string Nota { get; set; }

        public int CantidadVecesEncontradaVulnerable { get; set; }


        //[ForeignKey("Categoria")]
        //public int IdCategoria { get; set; }

        public int CompareTo(TarjetaCredito otraTarjeta)
        {
          return this.Categoria.Nombre.CompareTo(otraTarjeta.Categoria.Nombre);
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
