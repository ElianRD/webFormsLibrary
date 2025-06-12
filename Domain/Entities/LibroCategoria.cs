using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class LibroCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LibroId { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        // Navegación
        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
    }
}