using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(200)]
        public string Calle { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        [StringLength(100)]
        public string Estado { get; set; }

        [StringLength(10)]
        public string CodigoPostal { get; set; }

        [StringLength(100)]
        public string Pais { get; set; }

        public bool EsPrincipal { get; set; }

        // Navegación
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}