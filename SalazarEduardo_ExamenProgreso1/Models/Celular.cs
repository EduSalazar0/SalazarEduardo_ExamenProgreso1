using System.ComponentModel.DataAnnotations;

namespace SalazarEduardo_ExamenProgreso1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Modelo { get; set; }
        public int Anio { get; set; }
        [Range(100.00, 999.00,
            ErrorMessage = "El precio debe ir 100.00 and 999.00")]
        public double Precio { get; set; }

    }
}
