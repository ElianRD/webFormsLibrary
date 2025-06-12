
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Usuario
    {
        //public Usuario()
        //{
        //    FechaRegistro = DateTime.Now;
        //    Estado = "activo";
        //    Direcciones = new HashSet<Direccion>();
        //    Pedidos = new HashSet<Pedido>();
        //    Carritos = new HashSet<Carrito>();
        //    Reseñas = new HashSet<Reseña>();
        //    UsuarioRoles = new HashSet<UsuarioRol>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Contraseña { get; set; }

        public int? PerfilId { get; set; }
        public int? EmpleadoId { get; set; }
        public int? ClienteId { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        public DateTime? UltimoAcceso { get; set; }

        // Navegación
        [ForeignKey("PerfilId")]
        public virtual Perfil Perfil { get; set; }

        [ForeignKey("EmpleadoId")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<Reseña> Reseñas { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; }
    }
}
