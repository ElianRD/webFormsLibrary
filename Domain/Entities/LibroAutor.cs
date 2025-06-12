using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class LibroAutor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LibroId { get; set; }

        [Required]
        public int AutorId { get; set; }

        // Navegación
        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; }

        [ForeignKey("AutorId")]
        public virtual Autor Autor { get; set; }
    }

}