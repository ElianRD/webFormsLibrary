using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Venta
    {
        //public Venta()
        //{
        //    FechaVenta = DateTime.Now;
        //    Estado = "pendiente";
        //    DetallesVenta = new HashSet<DetalleVenta>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public int? EmpleadoProcesadorId { get; set; }

        public DateTime FechaVenta { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }

        public int DireccionEnvioId { get; set; }

        [StringLength(50)]
        public string MetodoPago { get; set; }

        // Navegación
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("EmpleadoProcesadorId")]
        public virtual Empleado EmpleadoProcesador { get; set; }

        [ForeignKey("DireccionEnvioId")]
        public virtual Direccion DireccionEnvio { get; set; }

        public virtual ICollection<DetalleVenta> DetallesVenta { get; set; }
    }
}