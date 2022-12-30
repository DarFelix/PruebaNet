using System.ComponentModel.DataAnnotations;

namespace PruebaNet.Models
{
    public class Contacto
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        public int Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public bool Verificado { get; set; }

    }
}
