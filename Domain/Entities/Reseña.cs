using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Reseña
    {
        public Reseña()
        {
            FechaReseña = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int LibroId { get; set; }

        [Range(1, 5)]
        public int Calificacion { get; set; }

        [StringLength(1000)]
        public string Comentario { get; set; }

        public DateTime FechaReseña { get; set; }

        // Navegación
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; }
    }

}