using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VentaId { get; set; }

        [Required]
        public int LibroId { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Subtotal { get; set; }

        // Navegación
        [ForeignKey("VentaId")]
        public virtual Venta Venta { get; set; }

        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; }
    }


}
