using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Carrito
    {
        //public Carrito()
        //{
        //    FechaAgregado = DateTime.Now;
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int LibroId { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaAgregado { get; set; }

        // Navegación
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; }
    }
}