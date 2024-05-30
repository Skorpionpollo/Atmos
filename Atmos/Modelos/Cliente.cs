using System.ComponentModel.DataAnnotations;

namespace Atmos.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del cliente no debe exceder los 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo del cliente es requerido")]
        [EmailAddress(ErrorMessage ="Introduce un correo válido")]
        [StringLength(100, ErrorMessage = "El correo del cliente no debe exceder los 100 caracteres")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El teléfono del cliente es requerido")]
        [StringLength(10, ErrorMessage = "El teléfono del cliente no debe exceder los 10 caracteres")]
        public string? Telefono { get; set; }

    }
}
