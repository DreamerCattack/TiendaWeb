using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaWeb.Models
{
    public class Producto
    {
        public int Id { get; set; }   // Clave primaria (por convención)

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "Precio (S/)")]
        [Range(0.01, 99999, ErrorMessage = "Ingrese un precio válido")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; } = DateTime.Today;

        [Range(0, 1000, ErrorMessage = "El stock debe estar entre 0 y 1000")]
        public int Stock { get; set; }

    }
}
