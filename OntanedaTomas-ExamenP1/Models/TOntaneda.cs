using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntanedaTomas_ExamenP1.Models
{
    public class TOntaneda
    {
        [Key]
        public int IdCPU {  get; set; }
        [Range(1,5)]
        public float VelocidadCPU { get; set; }
        [MaxLength(100)]
        public string Marca { get; set; }
        [Required]
        public bool EstaOverclokeado { get; set; }
        public DateOnly FechaObtencion { get; set; }
        public Celular Celular { get; set; }
        [ForeignKey("Celular")]
        public int IdCelular {  get; set; }

    }
}
