using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OntanedaTomas_ExamenP1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Modelo { get; set; }
        [Range(1980, 2024)]
        public int Anio { get; set; }
        [Required]
        [AllowNull]
        public float Precio { get; set; }
    }
}
