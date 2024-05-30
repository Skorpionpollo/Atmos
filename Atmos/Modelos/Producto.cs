using System.ComponentModel.DataAnnotations;

namespace Atmos.Modelos
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; } // Identificador único del producto

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del producto no debe exceder los 100 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripción del producto es requerida")]
        [StringLength(500, ErrorMessage = "La descripción del producto no debe exceder los 500 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es requerido")]
        [Range(0.01, 10000.00, ErrorMessage = "El precio del producto debe estar entre 0.01 y 10,000.00")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock del producto es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
        // Propiedad de navegación

        public int MarcasId { get; set; }
        virtual public Marca? Marcas { get; set;}
    }
}