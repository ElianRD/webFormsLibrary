using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UsuarioRol
    {
        //public UsuarioRol()
        //{
        //    FechaAsignacion = DateTime.Now;
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int RolId { get; set; }

        public DateTime FechaAsignacion { get; set; }

        // Navegación
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("RolId")]
        public virtual Rol Rol { get; set; }
    }
}