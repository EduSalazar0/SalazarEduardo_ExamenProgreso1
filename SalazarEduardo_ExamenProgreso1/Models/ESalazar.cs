using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace SalazarEduardo_ExamenProgreso1.Models
{
    public class ESalazar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
        [NotNull]
        public double Sueldo { get; set; }
        public bool TieneNovia { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Celular")]
        public int IdCelular {  get; set; }
        public virtual Celular? Celular { get; set; } = null!;


    }
}
