using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente
    {
        //public Cliente()
        //{
        //    Usuarios = new HashSet<Usuario>();
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

        [StringLength(100)]
        public string Ocupacion { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool EsClientePreferido { get; set; }

        // Navegación
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}