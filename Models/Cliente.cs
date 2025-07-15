using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Teléfono inválido.")]
        public string Telefono { get; set; }
    }
}
