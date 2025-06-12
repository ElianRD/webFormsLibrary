using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado
    {
        //public Empleado()
        //{
        //    Subordinados = new HashSet<Empleado>();
        //    Usuarios = new HashSet<Usuario>();
        //    VentasProcesadas = new HashSet<Venta>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [StringLength(10)]
        public string Genero { get; set; }

        [StringLength(500)]
        public string FotoPerfil { get; set; }

        [Required]
        [StringLength(20)]
        public string CodigoEmpleado { get; set; }

        [Required]
        [StringLength(100)]
        public string Cargo { get; set; }

        [StringLength(100)]
        public string Departamento { get; set; }

        public DateTime FechaContratacion { get; set; }

        [Column(TypeName = "decimal")]
        public decimal? Salario { get; set; }

        [StringLength(50)]
        public string Horario { get; set; }

        public int? SupervisorId { get; set; }

        // Navegación
        [ForeignKey("SupervisorId")]
        public virtual Empleado Supervisor { get; set; }

        public virtual ICollection<Empleado> Subordinados { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Venta> VentasProcesados { get; set; }
    }
}
